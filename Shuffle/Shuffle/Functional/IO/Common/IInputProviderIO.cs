using LanguageExt;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Ввод данных
/// </summary>
public interface IInputProviderIO
{
    /// <summary>
    /// Получить значение
    /// </summary>
    Option<string> GetValue(string question);
}