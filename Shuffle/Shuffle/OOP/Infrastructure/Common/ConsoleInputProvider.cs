namespace Shuffle.OOP.Infrastructure.Common;

/// <summary>
/// Ввод данных
/// </summary>
public class ConsoleInputProvider : IInputProvider
{
    /// <summary>
    /// Получить значение
    /// </summary>
    public string? GetValue(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }
}