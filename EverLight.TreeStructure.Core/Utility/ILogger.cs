namespace EverLight.TreeStructure.Core.Utility
{
    public interface ILogger
    {
        void Log(string message);
        void StartApplication();
        void EndApplication();
    }
}
