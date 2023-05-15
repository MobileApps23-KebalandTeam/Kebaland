using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model;
using UnityEngine;

namespace Core
{
    public class AchievementService : ISerializationService
    {
        public AchievementService()
        {
            try
            {
                Deserialize();
            }
            catch (FileNotFoundException e)
            {
                
            }
        }

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

        public bool Serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
                                          + "/Achievements.dat");
            bf.Serialize(file, _achievements);
            file.Close();
            return true;
        }

        public void Deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                File.Open(Application.persistentDataPath
                          + "/" + fileName(), FileMode.Open);
            List<MAchievement> list = (List<MAchievement>)bf.Deserialize(file);
            file.Close();
            if (list.Count > 0)
            {
                _achievements = list;
            }
            else
            {
                _achievements = new();
            }
        }

        public string fileName()
        {
            return "Achievements.dat";
        }
    }
}