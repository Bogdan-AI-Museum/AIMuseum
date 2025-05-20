using System;

namespace Services.Prompts.GoogleGeminis
{
    [Serializable]
    public class UnityAndGeminiKey
    {
        public string key;
    }

    [Serializable]
    public class Response
    {
        public Candidate[] candidates;
    }

    public class ChatRequest
    {
        public Content[] contents;
    }

    [Serializable]
    public class Candidate
    {
        public Content content;
    }

    [Serializable]
    public class Content
    {
        public string role; 
        public Part[] parts;
    }

    [Serializable]
    public class Part
    {
        public string text;
    }
}