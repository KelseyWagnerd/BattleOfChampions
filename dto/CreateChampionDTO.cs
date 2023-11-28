using BattleOfChampions.Models;

namespace BattleOfChampions.dto
{
    public class CreateChampionDTO
    {
       
            public Guid ChampionID { get; set; }
            public string Name { get; set; }
            public string Bio { get; set; }

            // Base stats-- do not change these for Battles! Use separate BattleStats table!
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Speed { get; set; }
            public int Health { get; set; }

            public string ?EquipmentId { get; set; }
    }
}
