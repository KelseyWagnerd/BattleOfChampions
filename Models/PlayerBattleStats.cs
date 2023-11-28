namespace BattleOfChampions.Models
{
    public class PlayerBattleStats
    {
        public Champion Player { get; set; }
        public int AdjustedAttack { get; }
        public int AdjustedDefense { get; }
        public int AdjustedSpeed { get; set; }
        public int AdjustedHealth { get; set; }

        public PlayerBattleStats()
        {
            AdjustedAttack = Player.Attack + Player.Equipment.AttackModifier;
            AdjustedDefense = Player.Defense + Player.Equipment.DefenseModifier;
            AdjustedSpeed = Player.Attack + Player.Equipment.AttackModifier;
            AdjustedHealth = Player.Attack + Player.Equipment.AttackModifier;
        }
    }
}

