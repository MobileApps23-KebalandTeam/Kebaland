using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Model;
using Core;
using System;

public class AchievementManager : MonoBehaviour
{
    //the preset for created later achievements
    public GameObject achievmentPrefab;
    [SerializeField] private GameObject achievementsScreen;
    //list of sprites for achievements done and undone
    public Sprite[] achievementsDoneSprites;
    public Sprite[] achievementsNotDoneSprites;
    private Dictionary<string, Achievement> achievementsList = new Dictionary<string, Achievement>();
    private bool achievementCreated = false;
    public GameObject visualAchievement;
    public bool mainMenuScreen;

    //public AchievementService k;

    private static AchievementManager instance;

    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        createAchievement("Pierwsze kroki", "Zacznij grać", 0);
        createAchievement("Arcydzieło", "Skończ pierwszy poziom", 1);
        createAchievement("Przepis na sukces", "Po raz pierwszy wejdż w osiągnięcia", 2);
        createAchievement("Space Wars", "Podołaj meksyków po raz pierwszy", 3);

        //PlayerPrefs.DeleteAll();
        loadAchievements();
    }

    // Update is called once per frame
    void Update()
    {

        if (mainMenuScreen && !achievementCreated && achievementsScreen.activeSelf)
        {
            foreach (var entry in achievementsList)
            {
                //put each achievement to achievement box and rescale it
                entry.Value.ReferenceObject.transform.SetParent(GameObject.Find("AchievementsBox").transform);
                entry.Value.ReferenceObject.transform.localScale = new Vector3(1, 1, 1);

                if (entry.Value.Unlocked) { entry.Value.ReferenceObject.transform.GetChild(0).GetComponent<Image>().sprite = achievementsDoneSprites[entry.Value.SpriteIndex]; }
            }

            achievementCreated = true;
        }
        else if (mainMenuScreen && achievementsScreen.activeSelf)
        {
            earnAchievement("Przepis na sukces");
        }
    }

    public void earnAchievement(string title)
    {
        if (achievementsList[title].isNotUnlocked())
        {
            GameObject show = (GameObject)Instantiate(visualAchievement);
            show.transform.SetParent(GameObject.Find("AchievementEarnedCanvas").transform);
            show.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title;
            show.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = achievementsList[title].Desc;
            show.transform.GetChild(0).GetComponent<Image>().sprite = achievementsDoneSprites[achievementsList[title].SpriteIndex];
            show.transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(hideAchievement(show));

            saveAchievement(title, true);

            if (!mainMenuScreen) { achievementCreated = false; }
        }
    }

    private void saveAchievement(string achievementTitle, bool value)
    {
        ///save achievement
        // k.AddAchievement(new MAchievement(achievementTitle, value, DateTime.Now.Ticks));
        // Debug.Log(k.GetCurrentAchievements().Count);


        //temporary solution is to save in Unity
        PlayerPrefs.SetInt(achievementTitle, value == true ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void loadAchievements()
    {
        //List<MAchievement> achievements = new AchievementService().GetCurrentAchievements();
        //int length = k.GetCurrentAchievements().Count;

        //Debug.Log(length);

        // foreach (MAchievement a in achievements)
        // {

        //     achievementsList[a.Name].isNotUnlocked();

        // }
        foreach (var item in achievementsList)
        {
            if (PlayerPrefs.GetInt(item.Key) == 1)
            {
                achievementsList[item.Value.Name].isNotUnlocked();
            }
        }

    }

    public IEnumerator hideAchievement(GameObject achievement)
    {
        //wait for two seconds before hiding achievement
        yield return new WaitForSeconds(2);
        Destroy(achievement);
    }


    public void createAchievement(string title, string desc, int spriteIndex)
    {
        //create new achievement
        GameObject achievementUI = (GameObject)Instantiate(achievmentPrefab);
        //add text to title and description
        achievementUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title;
        achievementUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = desc;

        //example of setting image
        achievementUI.transform.GetChild(0).GetComponent<Image>().sprite = achievementsNotDoneSprites[spriteIndex];

        //create achievement object to track if achievement is complete
        Achievement newAchievement = new Achievement(title, desc, spriteIndex, achievementUI);

        achievementsList.Add(title, newAchievement);
    }
}
