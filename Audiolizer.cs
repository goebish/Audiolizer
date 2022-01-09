using System;
using System.Linq;
using System.Timers;
using System.Net.Sockets;
using System.Collections.Generic;


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

        private static void OnAnalyzerTimer(Object source, ElapsedEventArgs e)
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

        private static void StartAnalyzerTimer()
        {
            aTimer = new System.Timers.Timer(15);
            aTimer.Elapsed += OnAnalyzerTimer;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        static void Main(string[] args)
        {
            StartAnalyzerTimer();
            settingsForm = new SettingsForm();
            settingsForm.Analyzer = analyzer;
            settingsForm.LoadSettings();
            settingsForm.ShowDialog();
        }
    }
}
