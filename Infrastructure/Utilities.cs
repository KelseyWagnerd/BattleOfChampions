using BattleOfChampions.AbstractClasses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BattleOfChampions.Infrastructure
{
    public class Utilities
    {
        private readonly IEquipmentLogic _equipmentLogic;
        public Utilities(IEquipmentLogic equipmentLogic)
        {
                _equipmentLogic = equipmentLogic;   
        }
        public async Task<List<SelectListItem>> GetEquipmentSL()
        {
            try
            {
                List<SelectListItem> EquipmentSelectList = new List<SelectListItem>();
                var equipments = await _equipmentLogic.getEquipmentList();
                if (equipments?.Count() > 0)
                {
                    var equipmentSelect = equipments
                                     .Select(s => new SelectListItem()
                                     {
                                         Text = s.Name,
                                         Value = s.EquipmentID.ToString()
                                     })
                                     .ToList();

                    if (equipments?.Count() > 0)
                    {

                        EquipmentSelectList.AddRange(equipmentSelect);
                    }
                }


                return EquipmentSelectList.OrderBy(f => f.Text).ToList();
            }
            catch (Exception) { throw; }
        }
    }
}
