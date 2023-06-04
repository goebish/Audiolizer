
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            groupBox_Mode = new System.Windows.Forms.GroupBox();
            radioButton_Spectrum = new System.Windows.Forms.RadioButton();
            radioButton_VolumePeak = new System.Windows.Forms.RadioButton();
            groupBox_Smoothing = new System.Windows.Forms.GroupBox();
            trackBar_Smoothing = new System.Windows.Forms.TrackBar();
            label_Smoothing = new System.Windows.Forms.Label();
            groupBox_SpectrumBands = new System.Windows.Forms.GroupBox();
            groupBox_Input = new System.Windows.Forms.GroupBox();
            comboBox_input = new System.Windows.Forms.ComboBox();
            groupBox_LedBarIP = new System.Windows.Forms.GroupBox();
            textBox_LedBarIP = new System.Windows.Forms.TextBox();
            label_about = new System.Windows.Forms.Label();
            groupBox_Spectrum = new System.Windows.Forms.GroupBox();
            radioButton_SpectrumPeak = new System.Windows.Forms.RadioButton();
            radioButton_SpectrumAverage = new System.Windows.Forms.RadioButton();
            timer_Spectrum = new System.Windows.Forms.Timer(components);
            groupBox_Scaling = new System.Windows.Forms.GroupBox();
            label_Scaling = new System.Windows.Forms.Label();
            trackBar_Scaling = new System.Windows.Forms.TrackBar();
            groupBox_Mode.SuspendLayout();
            groupBox_Smoothing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Smoothing).BeginInit();
            groupBox_Input.SuspendLayout();
            groupBox_LedBarIP.SuspendLayout();
            groupBox_Spectrum.SuspendLayout();
            groupBox_Scaling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Scaling).BeginInit();
            SuspendLayout();
            // 
            // groupBox_Mode
            // 
            groupBox_Mode.Controls.Add(radioButton_Spectrum);
            groupBox_Mode.Controls.Add(radioButton_VolumePeak);
            groupBox_Mode.Location = new System.Drawing.Point(13, 149);
            groupBox_Mode.Name = "groupBox_Mode";
            groupBox_Mode.Size = new System.Drawing.Size(212, 59);
            groupBox_Mode.TabIndex = 3;
            groupBox_Mode.TabStop = false;
            groupBox_Mode.Text = "Mode";
            // 
            // radioButton_Spectrum
            // 
            radioButton_Spectrum.AutoSize = true;
            radioButton_Spectrum.Location = new System.Drawing.Point(108, 22);
            radioButton_Spectrum.Name = "radioButton_Spectrum";
            radioButton_Spectrum.Size = new System.Drawing.Size(80, 19);
            radioButton_Spectrum.TabIndex = 1;
            radioButton_Spectrum.TabStop = true;
            radioButton_Spectrum.Text = "Sprectrum";
            radioButton_Spectrum.UseVisualStyleBackColor = true;
            radioButton_Spectrum.CheckedChanged += radioButton_Spectrum_CheckedChanged;
            // 
            // radioButton_VolumePeak
            // 
            radioButton_VolumePeak.AutoSize = true;
            radioButton_VolumePeak.Location = new System.Drawing.Point(7, 23);
            radioButton_VolumePeak.Name = "radioButton_VolumePeak";
            radioButton_VolumePeak.Size = new System.Drawing.Size(93, 19);
            radioButton_VolumePeak.TabIndex = 0;
            radioButton_VolumePeak.TabStop = true;
            radioButton_VolumePeak.Text = "Volume Peak";
            radioButton_VolumePeak.UseVisualStyleBackColor = true;
            radioButton_VolumePeak.CheckedChanged += radioButton_VolumePeak_CheckedChanged;
            // 
            // groupBox_Smoothing
            // 
            groupBox_Smoothing.Controls.Add(trackBar_Smoothing);
            groupBox_Smoothing.Controls.Add(label_Smoothing);
            groupBox_Smoothing.Location = new System.Drawing.Point(12, 214);
            groupBox_Smoothing.Name = "groupBox_Smoothing";
            groupBox_Smoothing.Size = new System.Drawing.Size(212, 58);
            groupBox_Smoothing.TabIndex = 4;
            groupBox_Smoothing.TabStop = false;
            groupBox_Smoothing.Text = "Smoothing";
            // 
            // trackBar_Smoothing
            // 
            trackBar_Smoothing.AutoSize = false;
            trackBar_Smoothing.LargeChange = 1;
            trackBar_Smoothing.Location = new System.Drawing.Point(2, 22);
            trackBar_Smoothing.Minimum = 1;
            trackBar_Smoothing.Name = "trackBar_Smoothing";
            trackBar_Smoothing.Size = new System.Drawing.Size(179, 30);
            trackBar_Smoothing.TabIndex = 4;
            trackBar_Smoothing.Value = 7;
            trackBar_Smoothing.Scroll += trackBar_Smoothing_Scroll;
            // 
            // label_Smoothing
            // 
            label_Smoothing.AutoSize = true;
            label_Smoothing.Location = new System.Drawing.Point(187, 19);
            label_Smoothing.Name = "label_Smoothing";
            label_Smoothing.Size = new System.Drawing.Size(19, 15);
            label_Smoothing.TabIndex = 3;
            label_Smoothing.Text = "10";
            // 
            // groupBox_SpectrumBands
            // 
            groupBox_SpectrumBands.Location = new System.Drawing.Point(198, 474);
            groupBox_SpectrumBands.Name = "groupBox_SpectrumBands";
            groupBox_SpectrumBands.Size = new System.Drawing.Size(62, 26);
            groupBox_SpectrumBands.TabIndex = 5;
            groupBox_SpectrumBands.TabStop = false;
            groupBox_SpectrumBands.Text = "Spectrum Filter";
            groupBox_SpectrumBands.Visible = false;
            // 
            // groupBox_Input
            // 
            groupBox_Input.Controls.Add(comboBox_input);
            groupBox_Input.Location = new System.Drawing.Point(13, 13);
            groupBox_Input.Name = "groupBox_Input";
            groupBox_Input.Size = new System.Drawing.Size(210, 61);
            groupBox_Input.TabIndex = 6;
            groupBox_Input.TabStop = false;
            groupBox_Input.Text = "Input";
            // 
            // comboBox_input
            // 
            comboBox_input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_input.FormattingEnabled = true;
            comboBox_input.Location = new System.Drawing.Point(7, 23);
            comboBox_input.Name = "comboBox_input";
            comboBox_input.Size = new System.Drawing.Size(197, 23);
            comboBox_input.TabIndex = 0;
            comboBox_input.SelectedIndexChanged += comboBox_input_SelectedIndexChanged;
            // 
            // groupBox_LedBarIP
            // 
            groupBox_LedBarIP.Controls.Add(textBox_LedBarIP);
            groupBox_LedBarIP.Location = new System.Drawing.Point(13, 81);
            groupBox_LedBarIP.Name = "groupBox_LedBarIP";
            groupBox_LedBarIP.Size = new System.Drawing.Size(210, 62);
            groupBox_LedBarIP.TabIndex = 7;
            groupBox_LedBarIP.TabStop = false;
            groupBox_LedBarIP.Text = "LedBar IP";
            // 
            // textBox_LedBarIP
            // 
            textBox_LedBarIP.Location = new System.Drawing.Point(7, 23);
            textBox_LedBarIP.Name = "textBox_LedBarIP";
            textBox_LedBarIP.Size = new System.Drawing.Size(197, 23);
            textBox_LedBarIP.TabIndex = 0;
            textBox_LedBarIP.TextChanged += textBox_LedBarIP_TextChanged;
            // 
            // label_about
            // 
            label_about.AutoSize = true;
            label_about.Location = new System.Drawing.Point(60, 475);
            label_about.Name = "label_about";
            label_about.Size = new System.Drawing.Size(111, 15);
            label_about.TabIndex = 8;
            label_about.Text = "v1.3 ©goebish 2023";
            // 
            // groupBox_Spectrum
            // 
            groupBox_Spectrum.Controls.Add(radioButton_SpectrumPeak);
            groupBox_Spectrum.Controls.Add(radioButton_SpectrumAverage);
            groupBox_Spectrum.Location = new System.Drawing.Point(11, 350);
            groupBox_Spectrum.Name = "groupBox_Spectrum";
            groupBox_Spectrum.Size = new System.Drawing.Size(212, 122);
            groupBox_Spectrum.TabIndex = 9;
            groupBox_Spectrum.TabStop = false;
            groupBox_Spectrum.Text = "Spectrum";
            // 
            // radioButton_SpectrumPeak
            // 
            radioButton_SpectrumPeak.AutoSize = true;
            radioButton_SpectrumPeak.Location = new System.Drawing.Point(132, 97);
            radioButton_SpectrumPeak.Name = "radioButton_SpectrumPeak";
            radioButton_SpectrumPeak.Size = new System.Drawing.Size(50, 19);
            radioButton_SpectrumPeak.TabIndex = 2;
            radioButton_SpectrumPeak.TabStop = true;
            radioButton_SpectrumPeak.Text = "Peak";
            radioButton_SpectrumPeak.UseVisualStyleBackColor = true;
            radioButton_SpectrumPeak.CheckedChanged += radioButton_SpectrumPeak_CheckedChanged;
            // 
            // radioButton_SpectrumAverage
            // 
            radioButton_SpectrumAverage.AutoSize = true;
            radioButton_SpectrumAverage.Location = new System.Drawing.Point(24, 97);
            radioButton_SpectrumAverage.Name = "radioButton_SpectrumAverage";
            radioButton_SpectrumAverage.Size = new System.Drawing.Size(68, 19);
            radioButton_SpectrumAverage.TabIndex = 1;
            radioButton_SpectrumAverage.TabStop = true;
            radioButton_SpectrumAverage.Text = "Average";
            radioButton_SpectrumAverage.UseVisualStyleBackColor = true;
            radioButton_SpectrumAverage.CheckedChanged += radioButton_SpectrumAverage_CheckedChanged;
            // 
            // timer_Spectrum
            // 
            timer_Spectrum.Tick += timer_Spectrum_Tick;
            // 
            // groupBox_Scaling
            // 
            groupBox_Scaling.Controls.Add(label_Scaling);
            groupBox_Scaling.Controls.Add(trackBar_Scaling);
            groupBox_Scaling.Location = new System.Drawing.Point(13, 278);
            groupBox_Scaling.Name = "groupBox_Scaling";
            groupBox_Scaling.Size = new System.Drawing.Size(210, 66);
            groupBox_Scaling.TabIndex = 10;
            groupBox_Scaling.TabStop = false;
            groupBox_Scaling.Text = " Scaling";
            // 
            // label_Scaling
            // 
            label_Scaling.AutoSize = true;
            label_Scaling.Location = new System.Drawing.Point(185, 23);
            label_Scaling.Name = "label_Scaling";
            label_Scaling.Size = new System.Drawing.Size(19, 15);
            label_Scaling.TabIndex = 1;
            label_Scaling.Text = "15";
            // 
            // trackBar_Scaling
            // 
            trackBar_Scaling.AutoSize = false;
            trackBar_Scaling.Location = new System.Drawing.Point(10, 23);
            trackBar_Scaling.Maximum = 25;
            trackBar_Scaling.Minimum = 1;
            trackBar_Scaling.Name = "trackBar_Scaling";
            trackBar_Scaling.Size = new System.Drawing.Size(170, 37);
            trackBar_Scaling.TabIndex = 0;
            trackBar_Scaling.Value = 9;
            trackBar_Scaling.Scroll += trackBar_Scaling_Scroll;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(238, 495);
            Controls.Add(groupBox_Scaling);
            Controls.Add(groupBox_Spectrum);
            Controls.Add(label_about);
            Controls.Add(groupBox_LedBarIP);
            Controls.Add(groupBox_Input);
            Controls.Add(groupBox_SpectrumBands);
            Controls.Add(groupBox_Smoothing);
            Controls.Add(groupBox_Mode);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Audiolizer";
            FormClosing += SettingsForm_FormClosing;
            groupBox_Mode.ResumeLayout(false);
            groupBox_Mode.PerformLayout();
            groupBox_Smoothing.ResumeLayout(false);
            groupBox_Smoothing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Smoothing).EndInit();
            groupBox_Input.ResumeLayout(false);
            groupBox_LedBarIP.ResumeLayout(false);
            groupBox_LedBarIP.PerformLayout();
            groupBox_Spectrum.ResumeLayout(false);
            groupBox_Spectrum.PerformLayout();
            groupBox_Scaling.ResumeLayout(false);
            groupBox_Scaling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Scaling).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.RadioButton radioButton_SpectrumPeak;
        private System.Windows.Forms.RadioButton radioButton_SpectrumAverage;
    }
}