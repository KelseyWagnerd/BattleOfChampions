using BattleOfChampions.AbstractClasses;
using BattleOfChampions.Data;
using BattleOfChampions.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleOfChampions.Logic
{
    public class ChampionLogic:IChampionLogic
    {
        private readonly ApplicationDbContext _context;
        private readonly IEquipmentLogic _equipmentLogic;
        public ChampionLogic(ApplicationDbContext context, IEquipmentLogic equipmentLogic)
        {
            _context = context; 
            _equipmentLogic=equipmentLogic;
        }
        public async Task<IEnumerable<Champion>> GetChampions()
        {
            var champions=await _context.Champion.ToListAsync();
            foreach (var item in champions)
            {
                item.Equipment = await _equipmentLogic.getEquipmentById(item.EquipmentID);
            }
            return champions;
        }
    }
}
