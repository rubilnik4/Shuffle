namespace Shuffle.Infrastructure;

/// <summary>
/// Логгер
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Записать в лог
    /// </summary>
    void Log(string message);
}