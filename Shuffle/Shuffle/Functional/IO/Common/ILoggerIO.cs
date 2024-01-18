using LanguageExt;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Логгер
/// </summary>
public interface ILoggerIO
{
    /// <summary>
    /// Записать строку
    /// </summary>
    Unit Log(string value);
}