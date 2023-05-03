using System.Collections.Generic;
using UnityEngine;


public class LevelChoice : MonoBehaviour
{
    private Dictionary<int, LockStatus> levelStatus = new Dictionary<int, LockStatus>();
    
    void Start()
    {
        readCurrentLevel();
    }

    // Update is called once per frame
    void Update()
    {
        saveCurrentLevel();
    }

    private void readCurrentLevel()
    {
        int currentLevel = 5;  // TODO: Read saved level ~ Krzychu

        for (int level = 1; level <= 5; level++)
        {
            GameObject levelButton = GameObject.Find("Planet-" + level);
            GameObject levelLockImage = GameObject.Find("LockPlanet-" + level);
            
            if (level <= currentLevel)
            {
                levelStatus.Add(level, LockStatus.UNLOCK);
                levelButton.SetActive(true);
                levelLockImage.SetActive(false);
            }
            else
            {
                levelStatus.Add(level, LockStatus.LOCK);
                levelButton.SetActive(false);
                levelLockImage.SetActive(true);
            }
        }
    }

    private void saveCurrentLevel()
    {
        // TODO: As above Krzychu
    }
}
