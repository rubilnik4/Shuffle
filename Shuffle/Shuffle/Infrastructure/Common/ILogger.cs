namespace Shuffle.Infrastructure.Common;

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