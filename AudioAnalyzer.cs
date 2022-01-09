namespace Audiolizer
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using CoreAudio;
    using Un4seen.Bass;
    using Un4seen.BassWasapi;
    public class AudioAnalyzer : IDisposable
    {
        #region Consts

        public const int MaxLines = 16;

        #endregion

        #region Fields

        private readonly float[] _fftDataBuffer;
        private int _lastOutputLevel;
        private int _lastOutputLevelCounter;
        private bool _listening;
        private WASAPIPROC _wasapiProcessCallback;
        private AudioDevice _currentAudioDevice;
        private MMDevice _mmAudioDevice;
        private float _masterVolume;
        private byte[] _spectrum;

        #endregion

        #region Properties

        public int smoothing { get; set; }
        public List<int> bands { get; set; }
        public string mode { get; set; }

        public byte[] spectrum {
            get {
                return _spectrum;
            }
        }
        // Get the list of audio devices
        public List<AudioDevice> AudioDevices
        {
            get
            {
                var result = new List<AudioDevice>();
                for (var i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
                { 
                    var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                    if (device.IsEnabled && device.IsLoopback)
                        result.Add(new AudioDevice(i, device.name));
                }
                return result;
            }
        }

        // Gets or sets the current audio device to use
        public AudioDevice CurrentAudioDevice
        {
            get
            {
                return this._currentAudioDevice;
            }
            set
            {
                if (value != null && this._currentAudioDevice != null && this._currentAudioDevice.DeviceId == value.DeviceId)
                    return;
                this._currentAudioDevice = value;

                if (value != null)
                {
                    BassWasapi.BASS_WASAPI_Free();
                    BassWasapi.BASS_WASAPI_Init(this._currentAudioDevice.DeviceId, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, this._wasapiProcessCallback, IntPtr.Zero);
                }
            }
        }

        // Gets or sets if the current audio device is listened
        public bool Listening
        {
            get
            {
                return this._listening;
            }
            set
            {
                if (this.CurrentAudioDevice == null)
                {
                    this._listening = false;
                    if (BassWasapi.BASS_WASAPI_IsStarted())
                        BassWasapi.BASS_WASAPI_Stop(true);
                    return;
                }
                if (this._listening != value)
                {
                    this._listening = value;
                    if (value)
                        BassWasapi.BASS_WASAPI_Start();
                    else
                        BassWasapi.BASS_WASAPI_Stop(true);
                    Thread.Sleep(500);
                }
            }
        }

        #endregion

        #region Constructors

        // Initializes an instance of the class
        public AudioAnalyzer()
        {
            this._fftDataBuffer = new float[1024];
            this._spectrum = new byte[MaxLines];
            this._wasapiProcessCallback = new WASAPIPROC(this.WasapiProcessCallBack);

            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
            Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            var devEnum = new MMDeviceEnumerator();
            this._mmAudioDevice = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            
            //this._mmAudioDevice.AudioEndpointVolume.OnVolumeNotification += this.AudioEndpointVolume_OnVolumeNotification;
        }

        #endregion

        #region Methods
        public Dictionary<string, byte> Analyze()
        {
            if (!Listening)
                return null;
            var result = new Dictionary<string, byte>();
            if (mode == "PeakVolume") {
                result = AnalyzePeakVolume();
            }
            else if (mode == "SpectrumFilter") {
                result = AnalyzeBassAverage();
            }
            return result;
        }

        public Dictionary<string, byte> AnalyzePeakVolume()
        {
            var result = new Dictionary<string, byte>();
            int lvalue = (int)(_mmAudioDevice.AudioMeterInformation.PeakValues[0] * 255);
            int rvalue = (int)(_mmAudioDevice.AudioMeterInformation.PeakValues[1] * 255);
            result.Add("left", (byte)lvalue);
            result.Add("right", (byte)rvalue);
            return result;
        }

        // Retrieves audio data from the device, makes an average of the bass, rounded to the Left and Right levels and returns the result.
        public Dictionary<string, byte> AnalyzeBassAverage()
        {
            var result = new Dictionary<string, byte>();
            if (!this.Listening)
                return null;

            _masterVolume = -(this._mmAudioDevice.AudioEndpointVolume.MasterVolumeLevelScalar - 1.1f); // The higher the volume of the PC is, the higher the values returned by BASS are low. A calculation based on the volume of the PC can counter this.
           
            var dataCount = BassWasapi.BASS_WASAPI_GetData(this._fftDataBuffer, (int)BASSData.BASS_DATA_FFT2048);
            if (dataCount < -1)
                return null;

            int j;
            int b1;
            float peak;
            var b0 = 0;
            var average = 0;

            if (bands != null)
            {
                for (int band = 0; band < MaxLines; band++)
                {
                    // compute band start (b0) & end (b1) in fft array
                    peak = 0;
                    if (band > 0)
                        b0 = 1+(int)Math.Pow(2, (band-1) * 10.0 / (MaxLines - 1));
                    b1 = (int)Math.Pow(2, band * 10.0 / (MaxLines - 1));
                    if (b1 > 1023)
                        b1 = 1023;
                    if (b1 <= b0)
                        b1 = b0 + 1;
                    // retrieve peak value of this band
                    for (; b0 < b1; b0++)
                        if (peak < this._fftDataBuffer[1 + b0])
                            peak = this._fftDataBuffer[1 + b0];
                    peak /= _masterVolume;
                    // convert to byte using a logarithm
                    j = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                    // rescale (previous formula returns values way over 255)
                    j >>= 2;
                    // limit
                    if (j > 255)
                        j = 255;
                    if (j < 0)
                        j = 0;
                    _spectrum[band] = (byte)j;
                    // add this band for averaging if selected
                    if (bands.Contains(band))
                        average += (byte)j;
                }
                if (bands.Count > 1)
                    average /= bands.Count;
            }
            var level = BassWasapi.BASS_WASAPI_GetLevel();
            var left = (double)Utils.LowWord32(level) / (double)ushort.MaxValue * 255;
            var right = (double)Utils.HighWord32(level) / (double)ushort.MaxValue * 255;
            left = average * (1 - (1 / (1 + left)));
            right = average * (1 - (1 / (1 + right)));

            result.Add("left", (byte)left);
            result.Add("right", (byte)right);

            if (level == this._lastOutputLevel && level != 0)
                this._lastOutputLevelCounter++;
            this._lastOutputLevel = level;

            // Resets analyzer if stuck
            if (this._lastOutputLevelCounter > 1000)
            {
                this._lastOutputLevelCounter = 0;
                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Init(this._currentAudioDevice.DeviceId, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, this._wasapiProcessCallback, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Start();
            }

            return result;
        }

        private int WasapiProcessCallBack(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        private void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {

        }

        public void Dispose()
        {
            this.CurrentAudioDevice = null;
            this.Listening = false;
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }

        #endregion
    }
}
