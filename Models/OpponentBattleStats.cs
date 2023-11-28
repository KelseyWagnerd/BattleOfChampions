using System.Numerics;

namespace BattleOfChampions.Models
{
    public class OpponentBattleStats
    {
        public Champion Opponent { get; set; }
        public int AdjustedAttack { get; }
        public int AdjustedDefense { get; }
        public int AdjustedSpeed { get; }
        public int AdjustedHealth { get; }
    }
    /*
    public OpponentBattleStats()
    {
        AdjustedAttack = Opponent.Attack + Opponent.Equipment.AttackModifier;
        AdjustedDefense = Opponent.Defense + Opponent.Equipment.DefenseModifier;
        AdjustedSpeed = Opponent.Attack + Opponent.Equipment.AttackModifier;
        AdjustedHealth = Opponent.Attack + Opponent.Equipment.AttackModifier;
    }*/
}
