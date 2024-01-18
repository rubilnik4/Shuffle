using LanguageExt;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Логгер
/// </summary>
public class LoggerIO: ILoggerIO
{
    /// <summary>
    /// Записать строку
    /// </summary>
    public Unit Log(string value)
    {
        Console.WriteLine(value);
        return Unit.Default;
    }
}