using System;
using Installers;
using Mechanics;
using TMPro;
using Zenject;

namespace Services.Outputs
{
    [Serializable]
    public class TextOutputService : IOutputService
    {
        private TMP_Text _text;

        [Inject]
        private void Construct(MuseumScreen screen)
        {
            _text = screen.OutText;
        }
        public void SetOutput(string text)
        {
            _text.text = text;
        }
    }
}