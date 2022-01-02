using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Audiolizer
{
    public partial class SettingsForm : Form
    {
        #region Consts

        #endregion

        #region Fields

        private AudioAnalyzer _analyzer;
        private List<CheckBox> _spectrumBands = new List<CheckBox>();
        private List<AudioDevice> _input_devices = new List<AudioDevice>();
        public Settings settings;

        #endregion

        #region Properties

        public AudioAnalyzer Analyzer
        {
            get
            {
                return this._analyzer;
            }
            set{
                this._analyzer = value;
                _analyzer.smoothing = trackBar_Smoothing.Value;
            }
        }

        #endregion

        #region Constructors

        public SettingsForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // sprectrum filter checkboxes
            CheckBox checkbox;
            ToolTip toolTip = new ToolTip();
            for (int i=0; i<AudioAnalyzer.MaxLines; i++) {
                checkbox = new CheckBox();
                checkbox.CheckAlign = ContentAlignment.TopCenter;
                checkbox.Tag = i.ToString();
                checkbox.Text = (i+1).ToString();
                const float step = 22050.0f / 1024.0f; // FFT2048 = 1024 points for 0-22050 Hz range
                int freq_start = 1;
                if (i > 0)
                    freq_start = (int)(1 + (int)Math.Pow(2, (i - 1) * 10.0 / (AudioAnalyzer.MaxLines - 1))*step);
                int freq_end = (int)((int)Math.Pow(2, i * 10.0 / (AudioAnalyzer.MaxLines - 1))*step);
                String tip = freq_start.ToString() + "-" + freq_end.ToString() + " Hz";
                toolTip.SetToolTip(checkbox, tip);
                checkbox.AutoSize = true;
                checkbox.Location = new Point(10 + (i > 7 ? i-8 : i) * 25, i > 7 ? 60 : 25);
                if (i >= 9)
                    checkbox.Location = new Point(10 + (i > 7 ? i - 8 : i) * 25 - 5, i > 7 ? 60 : 25);
                checkbox.MouseClick += new MouseEventHandler(this.checkbox_Click);
                _spectrumBands.Add(checkbox);
                this.groupBox_SpectrumBands.Controls.Add(_spectrumBands[i]);
            }
        }

        #endregion

        #region Methods

        public void LoadSettings()
        {
            if (File.Exists("settings"))
                settings = Settings.Load("settings");
            else
                settings = new Settings();

            trackBar_Smoothing.Value = settings.Smoothing;
            label_Smoothing.Text = Convert.ToString(trackBar_Smoothing.Value);
            _analyzer.smoothing = settings.Smoothing;

            textBox_LedBarIP.Text = settings.LedBarIP;
            Audiolizer.LedBarIP = settings.LedBarIP;

            if (settings.Mode == "PeakVolume")
            {
                radioButton_VolumePeak.Checked = true;
            }
            else if (settings.Mode == "SpectrumFilter")
            {
                radioButton_Spectrum.Checked = true;
            }
            _analyzer.mode = settings.Mode;

            foreach (var item in comboBox_input.Items)
            {
                if (comboBox_input.GetItemText(item) == settings.InputName)
                {
                    comboBox_input.SelectedItem = item;
                }
            }
            comboBox_input_SelectedIndexChanged(null, null);

            foreach (Control control in this.groupBox_SpectrumBands.Controls)
            {
                if (control.GetType().Name == "CheckBox")
                {
                    CheckBox checkbox = control as CheckBox;
                    int checkbox_tag = Convert.ToInt32(checkbox.Tag);
                    if(settings.SpectrumFilter.Contains(checkbox_tag))
                    {
                        checkbox.Checked = true;
                    }
                }
            }
            _analyzer.bands = settings.SpectrumFilter;
        }

        private Boolean CheckIP(String ip)
        {
            // check if this is an IPv4 address
            if (ip.Count(f => (f == '.')) != 3)
                return false;
            IPAddress address;
            return IPAddress.TryParse(ip, out address) && address.AddressFamily == AddressFamily.InterNetwork;
        }

        private void checkbox_Click(object sender, MouseEventArgs e)
        {
            List<int> selected = new List<int>();
            foreach (Control control in this.groupBox_SpectrumBands.Controls)
            {
                if (control.GetType().Name == "CheckBox")
                {
                    CheckBox checkbox = control as CheckBox;
                    if (checkbox.Checked)
                        selected.Add(Convert.ToInt32(checkbox.Tag));
                }
            }
            _analyzer.bands = selected;
            settings.SpectrumFilter = selected;
        }

        public void populateInputs(AudioDevice device) {
            _input_devices.Add(device);
            comboBox_input.Items.Add(device.DeviceName);
        }

        private void trackBar_Smoothing_Scroll(object sender, EventArgs e)
        {
            _analyzer.smoothing = trackBar_Smoothing.Value;
            settings.Smoothing = _analyzer.smoothing;
            label_Smoothing.Text = Convert.ToString(trackBar_Smoothing.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_VolumePeak.Checked) {
                _analyzer.mode = "PeakVolume";
                settings.Mode = _analyzer.mode;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Spectrum.Checked) {
                _analyzer.mode = "SpectrumFilter";
                settings.Mode = _analyzer.mode;
            }
        }

        private void comboBox_input_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (AudioDevice dev in _input_devices) {
                string selected = comboBox_input.GetItemText(comboBox_input.SelectedItem);
                if (dev.DeviceName == selected) {
                    _analyzer.Listening = false;
                    _analyzer.CurrentAudioDevice = dev;
                    _analyzer.Listening = true;
                    settings.InputName = dev.DeviceName;
                    break;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CheckIP(textBox_LedBarIP.Text)) {
                Audiolizer.LedBarIP = textBox_LedBarIP.Text;
                textBox_LedBarIP.BackColor = Color.White;
                settings.LedBarIP = Audiolizer.LedBarIP;
            }
            else {
                textBox_LedBarIP.BackColor = Color.Red;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Save("settings");
            Application.Exit();
        }

    }

    #endregion
}
