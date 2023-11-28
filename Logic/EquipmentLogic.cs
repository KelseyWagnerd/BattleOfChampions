using BattleOfChampions.AbstractClasses;
using BattleOfChampions.Data;
using BattleOfChampions.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleOfChampions.Logic
{
    public class EquipmentLogic:IEquipmentLogic
    {
        private readonly ApplicationDbContext _context;
        public EquipmentLogic( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> getEquipmentList() 
        {
            return await _context.Equipment.ToListAsync();
        }
        public async Task<Equipment> getEquipmentById(Guid? id)
        {
            if (id == null)
                return null;
            return await _context.Equipment.Where(f=>f.EquipmentID==id).FirstOrDefaultAsync();
        }
    }
}
