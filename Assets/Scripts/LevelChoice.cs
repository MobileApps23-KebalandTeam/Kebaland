using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject[] lockPlanets;

    private static int _currentLevelToPass;
    private static int _startedLevel;
    
    void Start()
    { 
        ReadCurrentLevel();
    }

    void Update()
    {
        SaveCurrentLevel();
    }

    public void StartLevel0()
    {
        _startedLevel = 0;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel1()
    {
        _startedLevel = 1;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel2()
    {
        _startedLevel = 2;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel3()
    {
        _startedLevel = 3;
        SceneManager.LoadScene("ClickerPlaceholder");
    }
    
    public void StartLevel4()
    {
        _startedLevel = 4;
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
            if (_startedLevel == _currentLevelToPass)
            {
                StarshipMove.SetTargetPosition(_currentLevelToPass);
                _currentLevelToPass++;
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

        if (_currentLevelToPass == 0)
        {
            StarshipMove.SetPositionForce(_currentLevelToPass); 
        }
        else
        {
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

    private void SaveCurrentLevel()
    {
        // TODO: As above Krzychu
    }
}
