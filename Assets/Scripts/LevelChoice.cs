using System;
using Core;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject[] lockPlanets;
    [SerializeField] private GameObject spaceship;

    private static int _currentLevelToPass;
    private static int _startedLevel;
    
    void Start()
    { 
        ReadCurrentLevel();
        AchievementManager.Instance.earnAchievement("Pierwsze kroki");
    }

    void Update()
    {
        if (_currentLevelToPass == 1)
        {
            AchievementManager.Instance.earnAchievement("Arcydzieło");
        }
    }

    public void StartLevel0()
    {
        _startedLevel = 0;
        SceneManager.LoadScene("IgridientsMenu2");
    }
 
    public void StartLevel1()
    {
        _startedLevel = 1;
        SceneManager.LoadScene("IgridientsMenu2");
    }

    public void StartLevel2()
    {
        _startedLevel = 2;
        SceneManager.LoadScene("IgridientsMenu2");
    }

    public void StartLevel3()
    {
        _startedLevel = 3;
        SceneManager.LoadScene("IgridientsMenu2");
    }

    public void StartLevel4()
    {
        _startedLevel = 4;
        SceneManager.LoadScene("IgridientsMenu2");
    }
    
    public void StartLevel5()
    {
        _startedLevel = 5;
        SceneManager.LoadScene("IgridientsMenu2");
    }
    
    public void StartLevel6()
    {
        _startedLevel = 6;
        SceneManager.LoadScene("IgridientsMenu2");
    }
    
    public void StartLevel7()
    {
        _startedLevel = 7;
        SceneManager.LoadScene("IgridientsMenu2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void UpdateLevel(bool nextLevel, LevelType mode) 
    {
        MLogbookEntry entry = new();
        entry.LevelNumber = _startedLevel;
        entry.passedTime = DateTime.Now.Ticks;
        entry.passed = nextLevel;
        entry.mode = mode;
        entry.first_time = (_startedLevel == _currentLevelToPass);
        ServiceLocator.Get<LogbookService>().AddEntry(entry);
        if (nextLevel && mode == LevelType.KEBAB)
        {
            if (_startedLevel == _currentLevelToPass)
            {
                StarshipMove.SetTargetPosition(_currentLevelToPass);
                _currentLevelToPass++;
                SaveCurrentLevel();
            }
        }
    }

    private void ReadCurrentLevel()
    {
        _currentLevelToPass = ServiceLocator.Get<GameStateService>().loadProgress().MaxLevel;

        if (planets == null || lockPlanets == null)
        {
            return;
        }

        if (_currentLevelToPass == 0)
        {
            spaceship.SetActive(false);
            StarshipMove.SetPositionForce(_currentLevelToPass);
        }
        else
        {
            spaceship.SetActive(true);
            StarshipMove.SetPositionForce(_currentLevelToPass - 1);
        }


        for (int level = 0; level < planets.Length; level++)
        {
            if (level <= _currentLevelToPass)
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

    private static void SaveCurrentLevel()
    {
        MGameState model = ServiceLocator.Get<GameStateService>().loadProgress();
        model.MaxLevel = _currentLevelToPass;
        ServiceLocator.Get<GameStateService>().saveProgress(model);
    }

    public static int GetStartedLevel()
    {
        return _startedLevel;
    }
}
