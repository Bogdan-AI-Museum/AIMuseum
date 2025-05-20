using Mechanics.Players;
using NaughtyAttributes;
using Services.Inputs;
using Services.Outputs;
using Services.Prompts;
using Services.Prompts.Configs;
using Services.Prompts.GoogleGeminis.Configs;
using UnityEngine;

namespace Mechanics
{
    public class MuseumConfig : ScriptableObject
    {
        [SerializeReference, SubclassSelector]
        public IInputService inputType;

        [SerializeReference, SubclassSelector] 
        public IPromptService promptType;

        [SerializeReference, SubclassSelector] 
        public IOutputService outputType;
        
        [Header("Other")]
        public GoogleGeminiConfig googleGemini;
        public PromptConfig prompt;
        public PlayerConfig player;

        [Button]
        private void FindSceneItems()
        {
            prompt.FindItems();
        }
    }
}