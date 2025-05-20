using System;
using Cysharp.Threading.Tasks;
using Installers;
using Mechanics;
using Services.Inputs;
using Services.Outputs;
using Services.Outputs.Voices;
using Services.Prompts;
using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    private IPromptService _promptService;
    private MuseumScreen _screen;
    private IInputService _inputService;
    private IOutputService _outputService;
    private bool _isAutoWelcome;

    [Inject]
    private void Construct(IPromptService promptService, IOutputService outputService,
        MuseumScreen screen, IInputService inputService, MuseumConfig config)
    {
        _isAutoWelcome = config.prompt.isAutoWelcome;
        _outputService = outputService;
        _inputService = inputService;
        _screen = screen;
        _promptService = promptService;
    }
        
    private void Start()
    {
        _inputService.Init();
        if (_isAutoWelcome)
        {
            SetResult(_promptService.SendWelcomeRequest());
        }
        
        _screen.SendButton.onClick.AddListener(SendRequest);
    }

    private void OnDestroy()
    {
        _inputService.Deinit();
        _screen.SendButton.onClick.RemoveListener(SendRequest);
    }

    private void SendRequest()
    {
        string input = _inputService.GetInput();
        SetResult(_promptService.SendRequest(input));
    }
    private async void SetResult(UniTask<string> request)
    {
        _screen.SendButton.interactable = false;
        
        string result = await request;
        string nameField = result.Replace("<name>", _screen.NameField.text);
        
        _outputService.SetOutput(nameField);
        _screen.SendButton.interactable = true;
    }
}