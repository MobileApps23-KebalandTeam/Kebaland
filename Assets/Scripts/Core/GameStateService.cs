using System.IO;
using Model;

namespace Core
{
    public class GameStateService : ISerializationService
    {
        private MGameState _gameState = null;

        public GameStateService()
        {
            try
            {
                Deserialize();
            }
            catch (FileNotFoundException e)
            {
            }
        }

        public bool Serialize()
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize()
        {
            throw new System.NotImplementedException();
        }

        public string fileName()
        {
            return "GameState.dat";
        }

        public void saveProgress(MGameState gameState)
        {
            this._gameState = gameState;
            Serialize();
        }

        public MGameState loadProgress()
        {
            return _gameState;
        }
    }
}