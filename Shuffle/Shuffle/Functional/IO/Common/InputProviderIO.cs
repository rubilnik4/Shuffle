using LanguageExt;
using Shuffle.OOP.Infrastructure.Common;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Ввод данных
/// </summary>
public class InputProviderIO: IInputProviderIO
{
    /// <summary>
    /// Получить значение
    /// </summary>
    public Option<string> GetValue(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }
}