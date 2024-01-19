using LanguageExt;
using LanguageExt.Common;
using Shuffle.OOP.Infrastructure.Common;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Ввод данных
/// </summary>
public class InputProviderIO : IInputProviderIO
{
    /// <summary>
    /// Получить значение
    /// </summary>
    public Option<string> GetValue(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }

    /// <summary>
    /// Получить значение
    /// </summary>
    public Option<int> GetNumber(string question)
    {
        Console.WriteLine(question);
        var key = Console.ReadLine();
        return Prelude.parseInt(key);
    }
}