using System;

namespace Model
{
    [Serializable]
    public class MGameState
    {
        public MGameState(string username, int maxLevel, bool sound)
        {
            this.Username = username;
            this.MaxLevel = maxLevel;
            this.sound = sound;
        }

        public MGameState()
        {
        }

        public string Username;
        public int MaxLevel;
        public bool sound = true;
    }
}