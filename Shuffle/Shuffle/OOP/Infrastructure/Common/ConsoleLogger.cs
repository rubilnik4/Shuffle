namespace Shuffle.OOP.Infrastructure.Common;

/// <summary>
/// Логгер
/// </summary>
public class ConsoleLogger : ILogger
{
    /// <summary>
    /// Записать в лог
    /// </summary>
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}