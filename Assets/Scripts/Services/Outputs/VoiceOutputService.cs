using System;
using System.Runtime.InteropServices;
using Services.Outputs.Voices;
using UnityEngine;

namespace Services.Outputs
{
    [Serializable]
    public class VoiceOutputService : IOutputService
    {
        public virtual void SetOutput(string text)
        {
            TtsRustVoice.Play(text);
        }
    }
}