using System;

namespace Services.Prompts.GoogleGeminis.Configs
{
    [Serializable]
    public class GoogleGeminiConfig
    {
        public string apiKey = "AIzaSyDg1Ap2j3WPor0Svt9h4HSMi2fy0NLIBzM";
        public string apiEndpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent";
    }
}