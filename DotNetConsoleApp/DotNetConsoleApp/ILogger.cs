namespace DotNetConsoleApp
{
    public interface ILogger
    {
        string file { get; set; }

        void log(string message);
    }
}