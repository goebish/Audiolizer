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
        private List<AudioDevice> _input_devices = new List<AudioDevice>();
        private Settings settings;

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
                _analyzer.scaling = trackBar_Scaling.Value;
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
            const float step = 22050.0f / 1024.0f; // FFT2048 = 1024 points for 0-22050 Hz range
            CheckBox checkbox;
            ToolTip toolTip = new ToolTip();
            for (int i=0; i<AudioAnalyzer.MaxLines; i++) {
                checkbox = new CheckBox();
                checkbox.CheckAlign = ContentAlignment.TopCenter;
                checkbox.Tag = i.ToString();
                checkbox.Text = (i+1).ToString();
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
                checkbox.MouseEnter += new EventHandler(this.checkbox_Enter);
                checkbox.MouseLeave += new EventHandler(this.checkbox_Leave);
                this.groupBox_SpectrumBands.Controls.Add(checkbox);
            }
            // spectrum bars
            VerticalProgressBar bar;
            for (int i = 0; i < AudioAnalyzer.MaxLines; i++)
            {
                bar = new VerticalProgressBar();
                bar.Width = (groupBox_Spectrum.Width-20) / AudioAnalyzer.MaxLines;
                bar.Height = 75;
                bar.Location = new Point((i*bar.Width)+10, 20);
                int freq_start = 1;
                if (i > 0)
                    freq_start = (int)(1 + (int)Math.Pow(2, (i - 1) * 10.0 / (AudioAnalyzer.MaxLines - 1)) * step);
                int freq_end = (int)((int)Math.Pow(2, i * 10.0 / (AudioAnalyzer.MaxLines - 1)) * step);
                String tip = freq_start.ToString() + "-" + freq_end.ToString() + " Hz";
                toolTip.SetToolTip(bar, tip);
                bar.Tag = i.ToString();
                bar.Style = ProgressBarStyle.Continuous;
                bar.MouseClick += new MouseEventHandler(this.SpectrumBar_Click);
                groupBox_Spectrum.Controls.Add(bar);
            }
            // start spectrum refresh timer
            timer_Spectrum.Interval = 40;
            timer_Spectrum.Start();
        }

        #endregion

        #region Methods

        public void LoadSettings()
        {
            if (File.Exists("settings"))
                settings = Settings.Load("settings");
            else
                settings = new Settings();
            // smoothing
            trackBar_Smoothing.Value = settings.Smoothing;
            label_Smoothing.Text = Convert.ToString(trackBar_Smoothing.Value);
            _analyzer.smoothing = settings.Smoothing;
            // scaling
            trackBar_Scaling.Value = settings.Scaling;
            label_Scaling.Text = Convert.ToString(trackBar_Scaling.Value - trackBar_Scaling.Minimum);
            _analyzer.scaling = trackBar_Scaling.Maximum - (trackBar_Scaling.Value - trackBar_Scaling.Minimum);
            // ledbar ip
            textBox_LedBarIP.Text = settings.LedBarIP;
            Audiolizer.LedBarIP = settings.LedBarIP;
            // mode
            if (settings.Mode == "PeakVolume")
            {
                radioButton_VolumePeak.Checked = true;
            }
            else if (settings.Mode == "SpectrumFilter")
            {
                radioButton_Spectrum.Checked = true;
            }
            _analyzer.mode = settings.Mode;
            // input device
            List<AudioDevice> devices = _analyzer.AudioDevices;
            foreach (AudioDevice device in devices)
            {
                populateInputs(device);
            }
            foreach (var item in comboBox_input.Items)
            {
                if (comboBox_input.GetItemText(item) == settings.InputName)
                {
                    comboBox_input.SelectedItem = item;
                }
            }
            comboBox_input_SelectedIndexChanged(null, null);
            // spectrum filter
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
            checkbox_Click( null, null);
        }

        private Boolean CheckIP(String ip)
        {
            // check if this is an IPv4 address
            if (ip.Count(f => (f == '.')) != 3)
                return false;
            IPAddress address;
            return IPAddress.TryParse(ip, out address) && address.AddressFamily == AddressFamily.InterNetwork;
        }

        private void checkbox_Enter(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            foreach (Control control in this.groupBox_Spectrum.Controls)
            {
                if (control.GetType().Name == "VerticalProgressBar")
                {
                    VerticalProgressBar bar = control as VerticalProgressBar;
                    if (Convert.ToInt32(bar.Tag) == Convert.ToInt32(checkbox.Tag))
                    {
                        bar.BackColor = Color.LimeGreen;
                        break;
                    }
                }
            }
        }

        private void checkbox_Leave(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            foreach (Control control in this.groupBox_Spectrum.Controls)
            {
                if (control.GetType().Name == "VerticalProgressBar")
                {
                    VerticalProgressBar bar = control as VerticalProgressBar;
                    if (_analyzer.bands.Contains(Convert.ToInt32(bar.Tag)))
                    {
                        bar.BackColor = Color.White;
                    }
                    else
                    {
                        bar.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void SpectrumBar_Click(object sender, MouseEventArgs e)
        {
            VerticalProgressBar bar = sender as VerticalProgressBar;
            foreach (Control control in this.groupBox_SpectrumBands.Controls)
            {
                CheckBox checkbox = control as CheckBox;
                if ((string)bar.Tag == (string)checkbox.Tag)
                {
                    checkbox.Checked = !checkbox.Checked;
                    checkbox_Click(checkbox, null);
                    break;
                }
            }
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
            foreach (Control control in this.groupBox_Spectrum.Controls)
            {
                if (control.GetType().Name == "VerticalProgressBar")
                {
                    VerticalProgressBar bar = control as VerticalProgressBar;
                    if (selected.Contains(Convert.ToInt32(bar.Tag)))
                        bar.BackColor = Color.White;
                    else
                        bar.BackColor = Color.LightGray;
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

        private void trackBar_Scaling_Scroll(object sender, EventArgs e)
        {
            _analyzer.scaling = trackBar_Scaling.Maximum - (trackBar_Scaling.Value - trackBar_Scaling.Minimum);
            settings.Scaling = trackBar_Scaling.Value;
            label_Scaling.Text = Convert.ToString(trackBar_Scaling.Value - trackBar_Scaling.Minimum);
        }        

        private void radioButton_VolumePeak_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_VolumePeak.Checked) {
                _analyzer.mode = "PeakVolume";
                settings.Mode = _analyzer.mode;
            }
        }

        private void radioButton_Spectrum_CheckedChanged(object sender, EventArgs e)
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

        private void textBox_LedBarIP_TextChanged(object sender, EventArgs e)
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

        private void timer_Spectrum_Tick(object sender, EventArgs e)
        {
            if (_analyzer != null)
            {
                foreach (Control control in this.groupBox_Spectrum.Controls)
                {
                    if (control.GetType().Name == "VerticalProgressBar")
                    {
                        VerticalProgressBar bar = control as VerticalProgressBar;
                        bar.Value = (byte)((float)_analyzer.spectrum[Convert.ToInt32(control.Tag)] / 2.55f);
                        if (bar.Value >= bar.Maximum)
                        {
                            bar.ForeColor = Color.Red;
                        }
                        else
                        {
                            bar.ForeColor = Color.DodgerBlue;
                        }
                    }
                }
            }
        }
    }

    #endregion
}
