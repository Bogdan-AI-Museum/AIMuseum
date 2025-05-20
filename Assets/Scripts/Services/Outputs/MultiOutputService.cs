using System;
using UnityEngine;
using Zenject;

namespace Services.Outputs
{
    [Serializable]
    public class MultiOutputService : VoiceOutputService
    {
        private TextOutputService _textOutputService;

        [Inject]
        private void Construct(IInstantiator instantiator)
        {
            _textOutputService = instantiator.Instantiate<TextOutputService>();
        }

        public override void SetOutput(string text)
        {
            base.SetOutput(text);
            _textOutputService.SetOutput(text);
        }
    }
}