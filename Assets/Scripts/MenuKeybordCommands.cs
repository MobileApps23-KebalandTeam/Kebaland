using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKeybordCommands : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject creatorsScreen;
    [SerializeField] private GameObject grayedOutScreen;
    [SerializeField] private Menu bindToLibrary;
    void Update()
    {
        // Check if Back was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (grayedOutScreen.activeSelf || creatorsScreen.activeSelf)
            {
                bindToLibrary.BackToMainMenu();
            }
            else
            {
                bindToLibrary.showExitMenu();
            }
            // Quit the application
        }
    }
}
