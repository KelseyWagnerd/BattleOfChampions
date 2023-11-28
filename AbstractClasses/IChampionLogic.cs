using BattleOfChampions.Models;

namespace BattleOfChampions.AbstractClasses
{
    public interface IChampionLogic
    {
        Task<IEnumerable<Champion>> GetChampions();
    }
}
