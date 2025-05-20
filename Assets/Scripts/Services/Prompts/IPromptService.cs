using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Services.Prompts
{
    public interface IPromptService
    {
        UniTask<string> SendWelcomeRequest();
        UniTask<string> SendRequest(string inputFieldText);
    }
}