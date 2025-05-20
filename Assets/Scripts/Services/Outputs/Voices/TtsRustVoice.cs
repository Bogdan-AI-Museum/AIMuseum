using System.Runtime.InteropServices;

namespace Services.Outputs.Voices
{
    //https://github.com/keijiro/UnityRustTts
    public static class TtsRustVoice
    {
        public static void Play(string text)
        {
            ttsrust_say(text);
        }
      
#if UNITY_EDITOR == false && (UNITY_IOS || UNITY_WEBGL)
        [DllImport("__Internal")] 
#else
        [DllImport("ttsrust")] 
#endif
        private static extern void ttsrust_say(string text);
    }
}