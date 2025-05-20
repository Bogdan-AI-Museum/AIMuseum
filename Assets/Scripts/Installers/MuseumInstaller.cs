using System;
using Mechanics;
using Services.Inputs;
using Services.Inputs.Whispers;
using Services.Outputs;
using Services.PlayerInputs;
using Services.Prompts;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MuseumInstaller : MonoInstaller
    {
        [SerializeField] private MuseumConfig config;
        [SerializeField] private MuseumScreen screen;
        [SerializeField] private WhisperBinder whisperBinder;
        
        public override void InstallBindings()
        {
            Container.Bind<MuseumConfig>().FromInstance(config).AsSingle();
            Container.Bind<MuseumScreen>().FromInstance(screen).AsSingle();
            whisperBinder.Bind(Container);
            BindServices();
        }

        private void BindServices()
        {
            Type inputType = config.inputType.GetType();
            Container.Bind<IInputService>().To(inputType).AsSingle();
            
            Type promptType = config.promptType.GetType();
            Container.Bind<IPromptService>().To(promptType).AsSingle();
            
            Type outputType = config.outputType.GetType();
            Container.Bind<IOutputService>().To(outputType).AsSingle();
            
            Container.Bind<IPlayerInput>().To<PcPlayerInput>().AsSingle();
        }
    }
}
