using System;

namespace Model
{
    [Serializable]
    public class MGameState
    {
        public MGameState(string username, long maxLevel)
        {
            this.Username = username;
            this.MaxLevel = maxLevel;
        }

        public MGameState()
        {
        }

        public string Username;
        public long MaxLevel;
    }
}