using BattleOfChampions.Models;

namespace BattleOfChampions.AbstractClasses
{
    public interface IEquipmentLogic
    {
        Task<IEnumerable<Equipment>> getEquipmentList();
        Task<Equipment> getEquipmentById(Guid? id);
    }
}
