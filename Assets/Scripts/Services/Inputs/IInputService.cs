namespace Services.Inputs
{
    public interface IInputService
    {
        void Init();
        void Deinit();
        string GetInput();
    }
}