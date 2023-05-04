using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class LevelChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] Planets;
    [SerializeField] private GameObject[] LockPlanets;
    
    public static int CurrentLevel = 0;
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
        StartedLevel = 0;
        SceneManager.LoadScene("Level1");
    }
    
    public void StartLevel2()
    {
        StartedLevel = 1;
        SceneManager.LoadScene("Level2");
    }
    
    public void StartLevel3()
    {
        StartedLevel = 2;
        SceneManager.LoadScene("Level3");
    }
    
    public void StartLevel4()
    {
        StartedLevel = 3;
        SceneManager.LoadScene("Level4");
    }
    
    public void StartLevel5()
    {
        StartedLevel = 4;
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

    public static void UpdateLevel(bool nextLevel) 
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

        if (Planets == null || LockPlanets == null)
        {
            return;
        }
        
        for (int level = 0; level < Planets.Length; level++)
        {
            if (level <= CurrentLevel)
            {
                Planets[level].SetActive(true);
                LockPlanets[level].SetActive(false);
            }
            else
            {
                Planets[level].SetActive(false);
                LockPlanets[level].SetActive(true);
            }
        }
    }

    private void SaveCurrentLevel()
    {
        // TODO: As above Krzychu
    }
}
