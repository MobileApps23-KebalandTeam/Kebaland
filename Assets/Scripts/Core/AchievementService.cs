using System.Collections.Generic;
using Model;

namespace Core
{
    public class AchievementService : AbstractSerializationService
    {
        //private List<MAchievement> _achievements = new();
        public List<MAchievement> _achievements = new();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public List<MAchievement> GetCurrentAchievements()
        {
            return _achievements;
        }

        public bool AddAchievement(MAchievement j)
        {
            _achievements.Add(j);
            return Serialize();
        }

        public void RemoveAchievement(MAchievement j)
        {
            _achievements.RemoveAll(x => x.Name == j.Name && x.Acquired == j.Acquired && x.AcquiredDate == j.AcquiredDate);
            Serialize();
        }

        override protected string fileName()
        {
            return "Achievements.dat";
        }

        protected override object objectToSave()
        {
            return _achievements;
        }

        protected override void handleLoad()
        {
            object deserialized = Deserialize<List<MAchievement>>();
            if (deserialized != null)
            {
                _achievements = (List<MAchievement>)deserialized;
            }
            else
            {
                _achievements = new();
            }
        }
    }
}