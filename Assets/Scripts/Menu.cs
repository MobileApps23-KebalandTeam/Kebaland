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
    [SerializeField] private GameObject achievementsScreen;

    [SerializeField] private GameObject kebalandLogo;
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
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void ShowAchievements()
    {
        //Loads Achievements Fragment
        mainMenuScreen.SetActive(false);
        kebalandLogo.SetActive(false);
        achievementsScreen.SetActive(true);

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
        kebalandLogo.SetActive(true);
        creatorsScreen.SetActive(false);
        achievementsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        grayedOutScreen.SetActive(false);
    }

    public void showExitMenu()
    {
        grayedOutScreen.SetActive(true);
    }
}
