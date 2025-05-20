using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Mechanics
{
    public enum ScreenInputMode
    {
        Text,
        Voice,
    }
    public class MuseumScreen : MonoBehaviour
    {
        [field: SerializeField] public Button SendButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI OutText { get; private set; }
        [field: SerializeField] public TMP_InputField InputField { get; private set; }
        [field: SerializeField] public TMP_InputField NameField { get; private set; }

        [field: Header("Record")]
        [field: SerializeField] public Button RecordButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TextRecordButton { get; private set; }
        [field: SerializeField] public GameObject VoiceIndicator { get; private set; } 
        [field: SerializeField] public GameObject VoiceOutline { get; private set; }

        [SerializeField] private TextMeshProUGUI currentItemText;
        private bool _isPause;

        [Inject]
        private void Construct()
        {
            SetEmptyCurrentItemText();
        }

        public void SetRecordTextRecordButton()
        {
            VoiceOutline.SetActive(false);
            TextRecordButton.text = "Записати";
        }

        public void SetStopTextRecordButton()
        {
            VoiceOutline.SetActive(true);
            TextRecordButton.text = "Зупинити";
        }

        public void SetInputMode(ScreenInputMode mode)
        {
            RecordButton.gameObject.SetActive(mode == ScreenInputMode.Voice);
            VoiceIndicator.SetActive(mode == ScreenInputMode.Voice);
            TextRecordButton.gameObject.SetActive(mode == ScreenInputMode.Voice);
        }

        public void SetCurrentItemText(string text)
        {
            if (_isPause == false)
            {
                currentItemText.text = text;
            }
        }
        
        public void SetEmptyCurrentItemText()
        {
            SetCurrentItemText("-------------------");
        }

        public void SetPauseShowCurrentItemText(bool isPause)
        {
            _isPause = isPause;
        }
    }
}