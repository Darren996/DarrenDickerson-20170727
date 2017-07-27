namespace DotNetConsoleApp
{
    public interface ILogger
    {
        bool isAdmin { get; set; }
        string file { get; set; }

        void log(string message);
    }
}