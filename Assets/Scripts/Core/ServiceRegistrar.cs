using System.IO;
using UnityEngine;

namespace Core
{
    public class ServiceRegistrar : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(Application.persistentDataPath);
            if (AbstractSerializationService.version > PlayerPrefs.GetInt("version", 0))
            {
                PlayerPrefs.SetInt("version",AbstractSerializationService.version);
                foreach (var file in Directory.GetFiles(Application.persistentDataPath))
                {
                    FileInfo file_info = new FileInfo(file);
                    file_info.Delete();
                }
            }
            ServiceLocator.Register(new AchievementService());
            ServiceLocator.Register(new GameStateService());
            ServiceLocator.Register(new LogbookService());
            ServiceLocator.Register(new IngredientsService());

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