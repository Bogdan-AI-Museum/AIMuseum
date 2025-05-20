using System;
using System.Collections.Generic;
using System.Linq;
using Mechanics;
using NaughtyAttributes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Prompts.Configs
{
    [Serializable]
    public class PromptConfig
    {
        public bool isAutoWelcome;
        public bool isBasePrompt;

        [ResizableTextArea]
        [ShowIf(nameof(isAutoWelcome))]
        public string welcomePrompt;
    
        [SerializeField] private string guideName;
        [SerializeField] private List<string> items;
            
        [ResizableTextArea] 
        [SerializeField] [ShowIf(nameof(isBasePrompt))] 
        private string basePrompt;
        public string GetFormatBasePrompt()
        {
            string listItems = string.Join(Environment.NewLine, items);
            string prompt = string.Format(basePrompt, guideName, listItems);
            Debug.Log("Base prompt: \n" + prompt);
            return prompt;
        }
        public void FindItems()
        {
            items = Object.FindObjectsOfType<Item>()
                .Select(_ => _.Name)
                .ToList();
        }
    }
}