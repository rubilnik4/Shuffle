using LanguageExt;
using LanguageExt.Common;
using Shuffle.Functional.Affections;
using Shuffle.Functional.Cards;
using Shuffle.Functional.IO.Common;

namespace Shuffle.Functional;

/// <summary>
/// Старт приложения
/// </summary>
public static class MenuProgram<TRun>
    where TRun : struct, IHasCardDeskStorage<TRun>, IHasLogger<TRun>, IHasInputProvider<TRun>
{
    /// <summary>
    /// Запустить
    /// </summary>
    public static Eff<TRun, Unit> Start() =>
        Prelude.repeat((from number in InputProvider<TRun>.GetNumber("Введите цифру до 1 до 5")
                       from _ in GetAction(number)
                       select Unit.Default) 
                       | Prelude.@catch(error => Logger<TRun>.Log(error.Message)));

    /// <summary>
    /// Выбрать действие
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static Eff<TRun, Unit> GetAction(int number) =>
        number switch
        {
            1 => CardDeckFManager<TRun>.CreateDeskCard(),
            2 => CardDeckFManager<TRun>.ShuffleDeskCard(),
            3 => CardDeckFManager<TRun>.ShowDeskCard(),
            4 => CardDeckFManager<TRun>.ShowDeskCardNames(),
            5 => CardDeckFManager<TRun>.DeleteDeskCard(),
            _ => Eff<TRun, Unit>.Fail(Error.New("Такой циферки нет"))
        };
}