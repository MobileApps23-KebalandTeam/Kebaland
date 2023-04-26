using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject creatorsScreen;
    void Start()
    {
        button = GetComponent<Button>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelsChoiceScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowAchievements()
    {
        //TODO
        //LOAD ACHIEVEMENTS FRAGMENT OF SCENE MAIN MENU
    }

    public void ShowCreators()
    {
        mainMenuScreen.SetActive(false);
        creatorsScreen.SetActive(true);
    }

    public void ChangeSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void BackToMainMenu()
    {
        creatorsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
