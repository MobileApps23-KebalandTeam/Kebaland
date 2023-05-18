using UnityEngine;

namespace Core
{
    public class ServiceRegistrar : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(Application.persistentDataPath);
            ServiceLocator.Register(new AchievementService());
            ServiceLocator.Register(new GameStateService());

            /***
             * EXAMPLE USAGE
             * THIS CODE SHOULD BE COMMENTED ON PRODUCTION!!!

            AchievementService k = ServiceLocator.Get<AchievementService>();
            Debug.Log(k.GetCurrentAchievements().Count);
            k.AddAchievement(new MAchievement("HELLO", true, DateTime.Now.Ticks));
            Debug.Log(new AchievementService().GetCurrentAchievements()[0].Name);
            GameStateService g = ServiceLocator.Get<GameStateService>();
            g.saveProgress(new MGameState("KW", 12));
            Debug.Log(new GameStateService().loadProgress().Username);

            ***/
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}