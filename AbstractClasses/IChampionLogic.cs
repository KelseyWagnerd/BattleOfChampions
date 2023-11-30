using BattleOfChampions.Models;

namespace BattleOfChampions.AbstractClasses
{
    // SOLID development: Interface Segregation Principle
    public interface IChampionLogic
    {
        Task<IEnumerable<Champion>> GetChampions();
    }
}
