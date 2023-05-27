using System;

namespace Model
{
    [Serializable]
    public class MAchievement
    {
        public MAchievement(string name, bool acquired, long date)
        {
            this.Name = name;
            this.AcquiredDate = date;
            this.Acquired = acquired;
        }

        public MAchievement()
        {
        }

        public string Name;
        public bool Acquired = false;
        public long AcquiredDate;
    }
}