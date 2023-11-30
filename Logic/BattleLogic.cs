using BattleOfChampions.Models;

namespace BattleOfChampions.Logic
{
    public class BattleLogic
    {
        private Champion ?_player;
        private Champion ?_opponent;

        // Get Champion from drop down list
        // Assign player to the Champion from players dropdown
        public Champion assignPlayer(Champion playerDropDown)
        {
            _player = playerDropDown;

            return _player;

        }

        public Champion assignOpponent(Champion opponentDropDown)
        {
            _opponent = opponentDropDown;
            return _opponent;
        }



        // Assign opponent to the Champion from opponents dropdown

    }
}
