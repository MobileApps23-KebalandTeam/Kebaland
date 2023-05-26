using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private List<GameObject> lives;
    
    [SerializeField] private GameObject endGameInfo;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;

    public int GetLivesCount()
    {
        return lives.Count;
    }

    public void SubtractLife()
    {
        int lifeNumber = GetLivesCount() - 1;
        Image life = lives[lifeNumber].gameObject.GetComponent<Image>();
        life.color = new Color(life.color.r, life.color.g, life.color.b, 0f);
        lives[lifeNumber].gameObject.GetComponent<LifePulsing>().SetActive(false);
        lives.Remove(lives[lifeNumber]);
        if (GetLivesCount() == 0)
        {
            
            tutorialText.SetActive(false);
            endGameInfo.GetComponentInChildren<TMP_Text>().text =
                "Guacamole okazało się zabójcze, \n trzeba ratować przed nim galaktykę!";
            endGameInfo.SetActive(true);
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            enemy.gameObject.GetComponent<EnemyShooting>().enabled = false;
            enemy.gameObject.GetComponent<EnemyMovement>().SetIsEnd(true);
            var bullets = FindObjectsOfType<BulletMoving>();
            foreach (var bullet in bullets)
            {
                bullet.enabled = false;
            }
        }
    }

}
