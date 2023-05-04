using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChoice : MonoBehaviour
{
    private Dictionary<int, LockStatus> levelStatus = new Dictionary<int, LockStatus>();
    public static int CurrentLevel = 1;
    public static int StartedLevel = 0;
    
    void Start()
    { 
        ReadCurrentLevel();
    }

    // Update is called once per frame
    void Update()
    {
        SaveCurrentLevel();
    }

    public void StartLevel1()
    {
        StartedLevel = 1;
        SceneManager.LoadScene("Level1");
    }
    
    public void StartLevel2()
    {
        StartedLevel = 2;
        SceneManager.LoadScene("Level2");
    }
    
    public void StartLevel3()
    {
        StartedLevel = 3;
        SceneManager.LoadScene("Level3");
    }
    
    public void StartLevel4()
    {
        StartedLevel = 4;
        SceneManager.LoadScene("Level4");
    }
    
    public void StartLevel5()
    {
        StartedLevel = 5;
        SceneManager.LoadScene("Level5");
    }
    
    public void StartClicker1()
    {
        SceneManager.LoadScene("Clicker1");
    }
    
    public void StartClicker2()
    {
        SceneManager.LoadScene("Clicker2");
    }
    
    public void StartClicker3()
    {
        SceneManager.LoadScene("Clicker3");
    }
    
    public void StartClicker4()
    {
        SceneManager.LoadScene("Clicker4");
    }

    public static void updateLevel(bool nextLevel) 
    {
        if (nextLevel)
        {
            if (StartedLevel == CurrentLevel)
            {
                CurrentLevel++;
            }
        }
    }

    private void ReadCurrentLevel()
    {
        // TODO: Read saved level ~ Krzychu

        for (int level = 1; level <= 5; level++)
        {
            
            GameObject levelButton = GameObject.Find("Planet-" + level);
            GameObject levelLockImage = GameObject.Find("LockPlanet-" + level);

            if (levelButton == null || levelLockImage == null)
            {
                continue;
            }
            
            if (level <= CurrentLevel)
            {
                levelStatus[level] = LockStatus.UNLOCK;
                levelButton.SetActive(true);
                levelLockImage.SetActive(false);
            }
            else
            {
                levelStatus[level] = LockStatus.LOCK;
                levelButton.SetActive(false);
                levelLockImage.SetActive(true);
            }
        }
    }

    private void SaveCurrentLevel()
    {
        // TODO: As above Krzychu
    }
}
