using Model;

namespace Core
{
    public class GameStateService : AbstractSerializationService
    {
        private MGameState _gameState = null;

        override protected string fileName()
        {
            return "GameState.dat";
        }

        protected override object objectToSave()
        {
            return _gameState;
        }

        protected override void handleLoad()
        {
            object deserialized = Deserialize<MGameState>();
            if (deserialized != null)
            {
                _gameState = (MGameState)deserialized;
            }
            else
            {
                _gameState = new MGameState();
            }
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