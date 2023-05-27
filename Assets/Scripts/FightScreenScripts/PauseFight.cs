using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseFight : MonoBehaviour
{
    [SerializeField] private Button backToMenu;
    [SerializeField] private Button resumeGame;
    [SerializeField] private Button enterPauseMode;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        backToMenu.onClick.AddListener(BackToMainMenu);
        resumeGame.onClick.AddListener(ResumeFight);
        enterPauseMode.onClick.AddListener(EnterPauseMode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnterPauseMode();
        }
    }

    public void EnterPauseMode()
    {
        gameObject.SetActive(true);
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        enemy.gameObject.GetComponent<EnemyMovement>().enabled = false;
        enemy.gameObject.GetComponent<EnemyShooting>().enabled = false;
        BulletMoving[] bullets = FindObjectsOfType<BulletMoving>();
        foreach (var bullet in bullets)
        {
            bullet.StopBullet();
            bullet.enabled = false;
        }
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeFight()
    {
        gameObject.SetActive(false);
        player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        enemy.gameObject.GetComponent<EnemyMovement>().enabled = true;
        enemy.gameObject.GetComponent<EnemyShooting>().enabled = true;
        BulletMoving[] bullets = FindObjectsOfType<BulletMoving>();
        foreach (var bullet in bullets)
        {
            bullet.StartBullet();
            bullet.enabled = true;
        }
    }
}
