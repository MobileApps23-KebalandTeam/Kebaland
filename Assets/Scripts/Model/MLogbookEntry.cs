using System;

namespace Model
{
    [Serializable]
    public class MLogbookEntry
    {
        public MLogbookEntry(int LevelNumber, long passedTime, bool passed, LevelType mode, bool first_time)
        {
            this.LevelNumber = LevelNumber;
            this.passedTime = passedTime;
            this.passed = passed;
            this.mode = mode;
            this.first_time = first_time;
        }

        public MLogbookEntry()
        {
        }
        
        public int LevelNumber;
        public long passedTime;
        public bool passed;
        public LevelType mode;
        public bool first_time;
    }
    [Serializable]
    public enum LevelType
    {
        CLICKER, KEBAB
    }
}