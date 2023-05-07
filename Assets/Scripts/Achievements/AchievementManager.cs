using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    //the preset for created later achievements
    public GameObject achievmentPrefab;
    [SerializeField] private GameObject achievementsScreen;
    //list of sprites for achievements done and undone
    public Sprite[] achievementsDoneSprites;
    public Sprite[] achievementsNotDoneSprites;
    public Dictionary<int, int> dict;

    public bool achievementCreated = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!achievementCreated && achievementsScreen.activeSelf)
        {
            createAchievement("Pierwsze kroki", "Zacznij grać", 0);
            createAchievement("Arcydzieło", "Skończ pierwszy lewel", 1);

            achievementCreated = true;
        }
    }

    public void createAchievement(string title, string desc, int spriteIndex) //,Sprite image)
    {
        //create new achievement
        GameObject achievement = (GameObject)Instantiate(achievmentPrefab);
        //put it to achievementsBox
        achievement.transform.SetParent(GameObject.Find("AchievementsBox").transform);
        //rescale it
        achievement.transform.localScale = new Vector3(1, 1, 1);
        //add text to title and description
        achievement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title;
        achievement.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = desc;

        //example of setting image
        achievement.transform.GetChild(0).GetComponent<Image>().sprite = achievementsNotDoneSprites[spriteIndex];
    }
}
