using System;
using System.Diagnostics;
using Installers;
using Mechanics;
using Whisper;
using Whisper.Utils;
using Zenject;
using Debug = UnityEngine.Debug;

namespace Services.Inputs
{
    [Serializable]
    public class WhisperVoiceInputService : IInputService
    {
        private WhisperManager _whisper;
        private MicrophoneRecord _microphoneRecord;
        private MuseumScreen _screen;
        private string _result;

        [Inject]
        private void Construct(WhisperManager whisper, MicrophoneRecord microphoneRecord, MuseumScreen screen)
        {
            _whisper = whisper;
            _microphoneRecord = microphoneRecord;
            _screen = screen;
        }

        public void Init()
        {
            _screen.SetInputMode(ScreenInputMode.Voice);

            _microphoneRecord.OnRecordStop += OnRecordStop;
            _screen.RecordButton.onClick.AddListener(OnButtonPressed);
        }

        public void Deinit()
        {
            _microphoneRecord.OnRecordStop -= OnRecordStop;
            _screen.RecordButton.onClick.RemoveListener(OnButtonPressed);
        }

        public virtual string GetInput()
        {
            return _screen.InputField.text;
        }

        private void OnButtonPressed()
        {
            if (_microphoneRecord.IsRecording == false)
            {
                _microphoneRecord.StartRecord();
                _screen.SetStopTextRecordButton();
            }
            else
            {
                _microphoneRecord.StopRecord();
                _screen.SetRecordTextRecordButton();
            }
        }
        
        private async void OnRecordStop(AudioChunk recordedAudio)
        {
            _screen.SetRecordTextRecordButton();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            WhisperResult result = await _whisper.GetTextAsync(recordedAudio.Data, recordedAudio.Frequency, recordedAudio.Channels);
            
            long time = stopwatch.ElapsedMilliseconds;
            float rate = recordedAudio.Length / (time * 0.001f);

            Debug.Log($"Time: {time} ms\nRate: {rate:F1}x");

            _screen.InputField.text = result.Result;
        }
    }
}