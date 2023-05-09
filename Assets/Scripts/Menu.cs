using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject creatorsScreen;
    [SerializeField] private GameObject grayedOutScreen;
    void Start()
    {
        button = GetComponent<Button>();
    }
    public void PlayGame()
    {
        // SceneManager.LoadScene("LevelsChoiceScene");
        SceneManager.LoadScene("GameLoopScene");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
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
        grayedOutScreen.SetActive(false);
    }

    public void showExitMenu()
    {
        grayedOutScreen.SetActive(true);
    }
}
