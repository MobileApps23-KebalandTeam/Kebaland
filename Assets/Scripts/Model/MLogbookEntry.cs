using System;

namespace Model
{
    [Serializable]
    public class MLogbookEntry
    {
        public MLogbookEntry(int LevelNumber, long passedTime)
        {
            this.LevelNumber = LevelNumber;
            this.passedTime = passedTime;
        }

        public MLogbookEntry()
        {
        }
        
        public int LevelNumber;
        public long passedTime;
    }
}