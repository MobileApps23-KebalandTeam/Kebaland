namespace Model
{
    public class MGameState
    {
        public MGameState(string username, bool acquired, long maxLevel)
        {
            this.Username = username;
            this.MaxLevel = maxLevel;
        }

        public string Username;
        public long MaxLevel;
    }
}