using LanguageExt;
using LanguageExt.Common;

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

    /// <summary>
    /// Получить значение
    /// </summary>
    Option<int> GetNumber(string question);
}