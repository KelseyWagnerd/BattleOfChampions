using BattleOfChampions.Models;

namespace BattleOfChampions.Logic
{
    public class BattleLogic
    {
        private Champion _player;
        private Champion _opponent;

        // Get Champion from drop down list
        // Assign player to the Champion from players dropdown
        public Champion assignPlayer (Champion playerDropDown)
        {
            _player = playerDropDown;
            return _player;
        }

        
        
        // Assign opponent to the Champion from opponents dropdown

    }
}
