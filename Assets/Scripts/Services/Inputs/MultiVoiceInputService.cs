using System;
using Services.Inputs.Whispers;
using Zenject;

namespace Services.Inputs
{
    [Serializable]
    public class MultiVoiceInputService : WhisperVoiceInputService
    {
        private TextInputService _textInputService;

        [Inject]
        private void Construct(IInstantiator instantiator)
        {
            _textInputService = instantiator.Instantiate<TextInputService>();
        }
        
        public override string GetInput()
        {
            string baseInput = base.GetInput();
            return string.IsNullOrEmpty(baseInput) 
                ? _textInputService.GetInput() 
                : baseInput;
        }
    }
}