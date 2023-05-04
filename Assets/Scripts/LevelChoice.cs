using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class LevelChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject[] lockPlanets;
    
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

    public void StartLevel0()
    {
        StartedLevel = 0;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel1()
    {
        StartedLevel = 1;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel2()
    {
        StartedLevel = 2;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel3()
    {
        StartedLevel = 3;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel4()
    {
        StartedLevel = 4;
        SceneManager.LoadScene("ClickerPlaceholder");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

        if (planets == null || lockPlanets == null)
        {
            return;
        }
        
        for (int level = 0; level < planets.Length; level++)
        {
            if (level <= CurrentLevel)
            {
                planets[level].SetActive(true);
                lockPlanets[level].SetActive(false);
            }
            else
            {
                planets[level].SetActive(false);
                lockPlanets[level].SetActive(true);
            }
        }
    }

    private void SaveCurrentLevel()
    {
        // TODO: As above Krzychu
    }
}
