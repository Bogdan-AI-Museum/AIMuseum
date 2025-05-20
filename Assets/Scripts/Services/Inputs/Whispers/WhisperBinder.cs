using System;
using UnityEngine;
using Whisper;
using Whisper.Utils;
using Zenject;

namespace Services.Inputs.Whispers
{
    [Serializable]
    public class WhisperBinder
    {
        [SerializeField] public WhisperManager whisper;
        [SerializeField] public MicrophoneRecord microphoneRecord;

        public void Bind(DiContainer Container)
        {
            Container.Bind<WhisperManager>().FromInstance(whisper).AsSingle();
            Container.Bind<MicrophoneRecord>().FromInstance(microphoneRecord).AsSingle();
        }
    }
}