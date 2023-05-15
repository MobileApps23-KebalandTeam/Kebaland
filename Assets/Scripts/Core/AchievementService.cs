using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model;
using UnityEngine;

namespace Core
{
    public class AchievementService : ISerializationService
    {
        private List<MAchievement> _achievements = new();

        public List<MAchievement> GetCurrentAchievements()
        {
            return _achievements;
        }

        public bool AddAchievement(MAchievement j)
        {
            _achievements.Add(j);
            return Serialize();
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
            object deserialized = Deserialize<MAchievement>();
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