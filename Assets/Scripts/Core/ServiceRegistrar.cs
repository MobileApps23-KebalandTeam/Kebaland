using System;
using Model;
using UnityEngine;

namespace Core
{
    public class ServiceRegistrar : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ServiceLocator.Register(new AchievementService());
            AchievementService k = ServiceLocator.Get<AchievementService>();
            Debug.Log(k.GetCurrentAchievements().Count);
            k.AddAchievement(new MAchievement("HELLO", true, DateTime.Now.Ticks));
            Debug.Log(new AchievementService().GetCurrentAchievements()[0]);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}