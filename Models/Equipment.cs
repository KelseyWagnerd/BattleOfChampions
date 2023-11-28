using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BattleOfChampions.Models
{
    public class Equipment
    {
        public string Name { get; set; }
        [Key]
        public Guid EquipmentID { get; set; }

        public int AttackModifier { get; set; }
        public int DefenseModifier { get; set; }
        public int SpeedModifier { get; set; }
        public int HealthModifier { get; set; }

        //public IEnumerable<SelectListItem> EquipmentList { get; set; }

        //public Equipment() { }
    }
}
