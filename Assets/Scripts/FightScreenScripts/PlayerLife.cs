using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private List<GameObject> lives;

    public int GetLivesCount()
    {
        return lives.Count;
    }

    public void SubtractLife()
    {
        int lifeNumber = GetLivesCount() - 1;
        Image life = lives[lifeNumber].gameObject.GetComponent<Image>();
        life.color = new Color(life.color.r, life.color.g, life.color.b, 0f);
        lives.Remove(lives[lifeNumber]);
        if (GetLivesCount() == 0)
        {
            LevelChoice.UpdateLevel(false);
            SceneManager.LoadScene("LevelsChoiceScene");
        }
    }

}
