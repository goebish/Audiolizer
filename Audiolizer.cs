using System;
using System.Linq;
using System.Timers;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Audiolizer
{
    class Audiolizer
    {
        private static System.Timers.Timer aTimer;
        public static String LedBarIP;
        private const int PORT = 9999;
        private static UdpClient udp = new UdpClient();
        private static List<int> left = new List<int>();
        private static List<int> right = new List<int>();
        private static AudioAnalyzer analyzer = new AudioAnalyzer();
        private static SettingsForm settingsForm;

        private static void OnTimer(Object source, ElapsedEventArgs e)
        {
            // run analyzer
            Dictionary<string, byte> data = analyzer.Analyze();
            if (data != null)
            {
                while (left.Count >= analyzer.smoothing)
                    left.RemoveAt(0);
                left.Add((byte)((float)data["left"] / 2.55f));
                while (right.Count >= analyzer.smoothing)
                    right.RemoveAt(0);
                right.Add((byte)((float)data["right"] / 2.55f));
                int peak = (int)(right.Average() + left.Average()) >> 1;
                byte[] payload = { (byte)peak };
                udp.SendAsync(payload, sizeof(byte), LedBarIP, PORT);
            }
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(15);
            aTimer.Elapsed += OnTimer;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        static void Main(string[] args)
        {
            settingsForm = new SettingsForm();
            settingsForm.Analyzer = analyzer;
            List<AudioDevice> devices = analyzer.AudioDevices;
            foreach (AudioDevice device in devices)
            {
                settingsForm.populateInputs(device);
            }
            settingsForm.LoadSettings();
            SetTimer();
            settingsForm.ShowDialog();
            Application.Run();
            analyzer.Dispose();
        }
    }
}
