using BattleOfChampions.Models;

namespace BattleOfChampions.AbstractClasses
{
    // SOLID development: Interface Segregation Principle
    public interface IEquipmentLogic
    {
        Task<IEnumerable<Equipment>> getEquipmentList();
        Task<Equipment> getEquipmentById(Guid? id);
    }
}
