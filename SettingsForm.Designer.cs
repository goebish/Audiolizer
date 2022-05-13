
namespace Audiolizer
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox_Mode = new System.Windows.Forms.GroupBox();
            this.radioButton_Spectrum = new System.Windows.Forms.RadioButton();
            this.radioButton_VolumePeak = new System.Windows.Forms.RadioButton();
            this.groupBox_Smoothing = new System.Windows.Forms.GroupBox();
            this.trackBar_Smoothing = new System.Windows.Forms.TrackBar();
            this.label_Smoothing = new System.Windows.Forms.Label();
            this.groupBox_SpectrumBands = new System.Windows.Forms.GroupBox();
            this.groupBox_Input = new System.Windows.Forms.GroupBox();
            this.comboBox_input = new System.Windows.Forms.ComboBox();
            this.groupBox_LedBarIP = new System.Windows.Forms.GroupBox();
            this.textBox_LedBarIP = new System.Windows.Forms.TextBox();
            this.label_about = new System.Windows.Forms.Label();
            this.groupBox_Spectrum = new System.Windows.Forms.GroupBox();
            this.timer_Spectrum = new System.Windows.Forms.Timer(this.components);
            this.groupBox_Scaling = new System.Windows.Forms.GroupBox();
            this.label_Scaling = new System.Windows.Forms.Label();
            this.trackBar_Scaling = new System.Windows.Forms.TrackBar();
            this.groupBox_Mode.SuspendLayout();
            this.groupBox_Smoothing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Smoothing)).BeginInit();
            this.groupBox_Input.SuspendLayout();
            this.groupBox_LedBarIP.SuspendLayout();
            this.groupBox_Scaling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Scaling)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Mode
            // 
            this.groupBox_Mode.Controls.Add(this.radioButton_Spectrum);
            this.groupBox_Mode.Controls.Add(this.radioButton_VolumePeak);
            this.groupBox_Mode.Location = new System.Drawing.Point(13, 149);
            this.groupBox_Mode.Name = "groupBox_Mode";
            this.groupBox_Mode.Size = new System.Drawing.Size(212, 59);
            this.groupBox_Mode.TabIndex = 3;
            this.groupBox_Mode.TabStop = false;
            this.groupBox_Mode.Text = "Mode";
            // 
            // radioButton_Spectrum
            // 
            this.radioButton_Spectrum.AutoSize = true;
            this.radioButton_Spectrum.Location = new System.Drawing.Point(108, 22);
            this.radioButton_Spectrum.Name = "radioButton_Spectrum";
            this.radioButton_Spectrum.Size = new System.Drawing.Size(80, 19);
            this.radioButton_Spectrum.TabIndex = 1;
            this.radioButton_Spectrum.TabStop = true;
            this.radioButton_Spectrum.Text = "Sprectrum";
            this.radioButton_Spectrum.UseVisualStyleBackColor = true;
            this.radioButton_Spectrum.CheckedChanged += new System.EventHandler(this.radioButton_Spectrum_CheckedChanged);
            // 
            // radioButton_VolumePeak
            // 
            this.radioButton_VolumePeak.AutoSize = true;
            this.radioButton_VolumePeak.Location = new System.Drawing.Point(7, 23);
            this.radioButton_VolumePeak.Name = "radioButton_VolumePeak";
            this.radioButton_VolumePeak.Size = new System.Drawing.Size(93, 19);
            this.radioButton_VolumePeak.TabIndex = 0;
            this.radioButton_VolumePeak.TabStop = true;
            this.radioButton_VolumePeak.Text = "Volume Peak";
            this.radioButton_VolumePeak.UseVisualStyleBackColor = true;
            this.radioButton_VolumePeak.CheckedChanged += new System.EventHandler(this.radioButton_VolumePeak_CheckedChanged);
            // 
            // groupBox_Smoothing
            // 
            this.groupBox_Smoothing.Controls.Add(this.trackBar_Smoothing);
            this.groupBox_Smoothing.Controls.Add(this.label_Smoothing);
            this.groupBox_Smoothing.Location = new System.Drawing.Point(12, 214);
            this.groupBox_Smoothing.Name = "groupBox_Smoothing";
            this.groupBox_Smoothing.Size = new System.Drawing.Size(212, 58);
            this.groupBox_Smoothing.TabIndex = 4;
            this.groupBox_Smoothing.TabStop = false;
            this.groupBox_Smoothing.Text = "Smoothing";
            // 
            // trackBar_Smoothing
            // 
            this.trackBar_Smoothing.AutoSize = false;
            this.trackBar_Smoothing.LargeChange = 1;
            this.trackBar_Smoothing.Location = new System.Drawing.Point(2, 22);
            this.trackBar_Smoothing.Minimum = 1;
            this.trackBar_Smoothing.Name = "trackBar_Smoothing";
            this.trackBar_Smoothing.Size = new System.Drawing.Size(179, 30);
            this.trackBar_Smoothing.TabIndex = 4;
            this.trackBar_Smoothing.Value = 7;
            this.trackBar_Smoothing.Scroll += new System.EventHandler(this.trackBar_Smoothing_Scroll);
            // 
            // label_Smoothing
            // 
            this.label_Smoothing.AutoSize = true;
            this.label_Smoothing.Location = new System.Drawing.Point(187, 19);
            this.label_Smoothing.Name = "label_Smoothing";
            this.label_Smoothing.Size = new System.Drawing.Size(19, 15);
            this.label_Smoothing.TabIndex = 3;
            this.label_Smoothing.Text = "10";
            // 
            // groupBox_SpectrumBands
            // 
            this.groupBox_SpectrumBands.Location = new System.Drawing.Point(181, 453);
            this.groupBox_SpectrumBands.Name = "groupBox_SpectrumBands";
            this.groupBox_SpectrumBands.Size = new System.Drawing.Size(62, 26);
            this.groupBox_SpectrumBands.TabIndex = 5;
            this.groupBox_SpectrumBands.TabStop = false;
            this.groupBox_SpectrumBands.Text = "Spectrum Filter";
            this.groupBox_SpectrumBands.Visible = false;
            // 
            // groupBox_Input
            // 
            this.groupBox_Input.Controls.Add(this.comboBox_input);
            this.groupBox_Input.Location = new System.Drawing.Point(13, 13);
            this.groupBox_Input.Name = "groupBox_Input";
            this.groupBox_Input.Size = new System.Drawing.Size(210, 61);
            this.groupBox_Input.TabIndex = 6;
            this.groupBox_Input.TabStop = false;
            this.groupBox_Input.Text = "Input";
            // 
            // comboBox_input
            // 
            this.comboBox_input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_input.FormattingEnabled = true;
            this.comboBox_input.Location = new System.Drawing.Point(7, 23);
            this.comboBox_input.Name = "comboBox_input";
            this.comboBox_input.Size = new System.Drawing.Size(197, 23);
            this.comboBox_input.TabIndex = 0;
            this.comboBox_input.SelectedIndexChanged += new System.EventHandler(this.comboBox_input_SelectedIndexChanged);
            // 
            // groupBox_LedBarIP
            // 
            this.groupBox_LedBarIP.Controls.Add(this.textBox_LedBarIP);
            this.groupBox_LedBarIP.Location = new System.Drawing.Point(13, 81);
            this.groupBox_LedBarIP.Name = "groupBox_LedBarIP";
            this.groupBox_LedBarIP.Size = new System.Drawing.Size(210, 62);
            this.groupBox_LedBarIP.TabIndex = 7;
            this.groupBox_LedBarIP.TabStop = false;
            this.groupBox_LedBarIP.Text = "LedBar IP";
            // 
            // textBox_LedBarIP
            // 
            this.textBox_LedBarIP.Location = new System.Drawing.Point(7, 23);
            this.textBox_LedBarIP.Name = "textBox_LedBarIP";
            this.textBox_LedBarIP.Size = new System.Drawing.Size(197, 23);
            this.textBox_LedBarIP.TabIndex = 0;
            this.textBox_LedBarIP.TextChanged += new System.EventHandler(this.textBox_LedBarIP_TextChanged);
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.Location = new System.Drawing.Point(64, 453);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(111, 15);
            this.label_about.TabIndex = 8;
            this.label_about.Text = "v1.2 ©goebish 2022";
            // 
            // groupBox_Spectrum
            // 
            this.groupBox_Spectrum.Location = new System.Drawing.Point(11, 350);
            this.groupBox_Spectrum.Name = "groupBox_Spectrum";
            this.groupBox_Spectrum.Size = new System.Drawing.Size(212, 100);
            this.groupBox_Spectrum.TabIndex = 9;
            this.groupBox_Spectrum.TabStop = false;
            this.groupBox_Spectrum.Text = "Spectrum";
            // 
            // timer_Spectrum
            // 
            this.timer_Spectrum.Tick += new System.EventHandler(this.timer_Spectrum_Tick);
            // 
            // groupBox_Scaling
            // 
            this.groupBox_Scaling.Controls.Add(this.label_Scaling);
            this.groupBox_Scaling.Controls.Add(this.trackBar_Scaling);
            this.groupBox_Scaling.Location = new System.Drawing.Point(13, 278);
            this.groupBox_Scaling.Name = "groupBox_Scaling";
            this.groupBox_Scaling.Size = new System.Drawing.Size(210, 66);
            this.groupBox_Scaling.TabIndex = 10;
            this.groupBox_Scaling.TabStop = false;
            this.groupBox_Scaling.Text = " Scaling";
            // 
            // label_Scaling
            // 
            this.label_Scaling.AutoSize = true;
            this.label_Scaling.Location = new System.Drawing.Point(185, 23);
            this.label_Scaling.Name = "label_Scaling";
            this.label_Scaling.Size = new System.Drawing.Size(19, 15);
            this.label_Scaling.TabIndex = 1;
            this.label_Scaling.Text = "15";
            // 
            // trackBar_Scaling
            // 
            this.trackBar_Scaling.AutoSize = false;
            this.trackBar_Scaling.Location = new System.Drawing.Point(10, 23);
            this.trackBar_Scaling.Maximum = 20;
            this.trackBar_Scaling.Minimum = 5;
            this.trackBar_Scaling.Name = "trackBar_Scaling";
            this.trackBar_Scaling.Size = new System.Drawing.Size(170, 37);
            this.trackBar_Scaling.TabIndex = 0;
            this.trackBar_Scaling.Value = 15;
            this.trackBar_Scaling.Scroll += new System.EventHandler(this.trackBar_Scaling_Scroll);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 474);
            this.Controls.Add(this.groupBox_Scaling);
            this.Controls.Add(this.groupBox_Spectrum);
            this.Controls.Add(this.label_about);
            this.Controls.Add(this.groupBox_LedBarIP);
            this.Controls.Add(this.groupBox_Input);
            this.Controls.Add(this.groupBox_SpectrumBands);
            this.Controls.Add(this.groupBox_Smoothing);
            this.Controls.Add(this.groupBox_Mode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Audiolizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.groupBox_Mode.ResumeLayout(false);
            this.groupBox_Mode.PerformLayout();
            this.groupBox_Smoothing.ResumeLayout(false);
            this.groupBox_Smoothing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Smoothing)).EndInit();
            this.groupBox_Input.ResumeLayout(false);
            this.groupBox_LedBarIP.ResumeLayout(false);
            this.groupBox_LedBarIP.PerformLayout();
            this.groupBox_Scaling.ResumeLayout(false);
            this.groupBox_Scaling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Scaling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Mode;
        private System.Windows.Forms.RadioButton radioButton_Spectrum;
        private System.Windows.Forms.RadioButton radioButton_VolumePeak;
        private System.Windows.Forms.GroupBox groupBox_Smoothing;
        private System.Windows.Forms.TrackBar trackBar_Smoothing;
        private System.Windows.Forms.Label label_Smoothing;
        private System.Windows.Forms.GroupBox groupBox_SpectrumBands;
        private System.Windows.Forms.GroupBox groupBox_Input;
        private System.Windows.Forms.ComboBox comboBox_input;
        private System.Windows.Forms.GroupBox groupBox_LedBarIP;
        private System.Windows.Forms.TextBox textBox_LedBarIP;
        private System.Windows.Forms.Label label_about;
        private System.Windows.Forms.GroupBox groupBox_Spectrum;
        private System.Windows.Forms.Timer timer_Spectrum;
        private System.Windows.Forms.GroupBox groupBox_Scaling;
        private System.Windows.Forms.TrackBar trackBar_Scaling;
        private System.Windows.Forms.Label label_Scaling;
    }
}