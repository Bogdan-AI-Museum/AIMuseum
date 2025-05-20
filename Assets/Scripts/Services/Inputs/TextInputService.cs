using System;
using Installers;
using Mechanics;
using TMPro;
using Zenject;

namespace Services.Inputs
{
    [Serializable]
    public class TextInputService : IInputService
    {
        private TMP_InputField _inputField;
        private MuseumScreen _screen;

        [Inject]
        private void Construct(MuseumScreen screen)
        {
            _screen = screen;
            _inputField = screen.InputField;
            _inputField.textComponent.enableWordWrapping = true;
        }

        public void Init()
        {
            _screen.SetInputMode(ScreenInputMode.Text);
        }

        public void Deinit() { }

        public string GetInput()
        {
            return _inputField.text;
        }
    }
}