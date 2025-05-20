using System;
using System.Collections.Generic;
using System.Text;
using Cysharp.Threading.Tasks;
using Installers;
using Mechanics;
using Services.Outputs.Voices;
using Services.Prompts.Configs;
using Services.Prompts.GoogleGeminis.Configs;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Services.Prompts.GoogleGeminis
{
    [Serializable]
    public class GoogleGeminiPromptService : IPromptService
    {
        private Content[] _chatHistory;
        private PromptConfig _configPrompt;
        private GoogleGeminiConfig _configGoogleGemini;

        [Inject]
        private void Construct(MuseumConfig config)
        {
            _configPrompt = config.prompt;
            _configGoogleGemini = config.googleGemini;

            _chatHistory = new[]
            {
                new Content
                {
                    role = "user",
                    parts = new[]
                    {
                        new Part
                        {
                            text = config.prompt.isBasePrompt 
                                ? _configPrompt.GetFormatBasePrompt() 
                                : string.Empty
                        }
                    }
                }
            };
        }

        public async UniTask<string> SendWelcomeRequest()
        {
            return await SendRequest(_configPrompt.welcomePrompt);
        }
        public async UniTask<string> SendRequest(string newMessage)
        {
            Debug.Log("Start Request: " + newMessage);
            
            var url = $"{_configGoogleGemini.apiEndpoint}?key={_configGoogleGemini.apiKey}";
            var userContent = new Content
            {
                role = "user",
                parts = new[] { new Part { text = newMessage } }
            };

            var contentsList = new List<Content>(_chatHistory) { userContent };
            _chatHistory = contentsList.ToArray();

            var chatRequest = new ChatRequest { contents = _chatHistory };
            string jsonData = JsonUtility.ToJson(chatRequest);

            using var www = new UnityWebRequest(url, "POST");
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            await www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                var response = JsonUtility.FromJson<Response>(www.downloadHandler.text);
                if (response.candidates.Length > 0 && response.candidates[0].content.parts.Length > 0)
                {
                    string reply = response.candidates[0].content.parts[0].text;
                    var botContent = new Content { role = "model", parts = new[] { new Part { text = reply } } };
                
                    Debug.Log(reply);
                    contentsList.Add(botContent);
                    _chatHistory = contentsList.ToArray();
                    return reply;
                }
            
                Debug.Log("No text found.");
            }

            Debug.Log("Stop Request");
            throw new InvalidOperationException();
        }
    }
}