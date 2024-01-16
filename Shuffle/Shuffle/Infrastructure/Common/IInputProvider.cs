namespace Shuffle.Infrastructure.Common;

/// <summary>
/// Ввод данных
/// </summary>
public interface IInputProvider
{
    /// <summary>
    /// Получить значение
    /// </summary>
    string? GetValue(string question);
}