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
    public List<GameObject> achievementsUIList = new List<GameObject>();

    public Dictionary<string, Achievement> achievementsList = new Dictionary<string, Achievement>();
    public bool achievementCreated = false;
    public bool valuesUpdated = false;

    public GameObject visualAchievement;

    public AchievementService k;

    private static AchievementManager instance;

    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }
            return AchievementManager.instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        createAchievement("Pierwsze kroki", "Zacznij grać", 0);
        createAchievement("Arcydzieło", "Skończ pierwszy lewel", 1);


        loadAchievements();

        //Debug.Log(k.GetCurrentAchievements().Count);

    }

    // Update is called once per frame
    void Update()
    {
        // if (!valuesUpdated)
        // {
        //     valuesUpdated = true;
        //     k = ServiceLocator.Get<AchievementService>();

        //     if (new AchievementService().GetCurrentAchievements().Count != 0)
        //     {
        //         Debug.Log("Got here");
        //         loadAchievements();
        //     }
        // }

        if (!achievementCreated && achievementsScreen.activeSelf)
        {
            foreach (var entry in achievementsList)
            {
                //put each achievement to achievement box and rescale it
                entry.Value.ReferenceObject.transform.SetParent(GameObject.Find("AchievementsBox").transform);
                entry.Value.ReferenceObject.transform.localScale = new Vector3(1, 1, 1);
            }

            achievementCreated = true;
        }
        else if (achievementsScreen.activeSelf)
        {
            // GameObject g = achievementsUIList[1];
            // g.transform.GetChild(0).GetComponent<Image>().sprite = achievementsDoneSprites[0];
            earnAchievement("Pierwsze kroki");
        }
    }

    public void earnAchievement(string title)
    {
        if (achievementsList[title].isNotUnlocked())
        {
            Debug.Log("Everytime entering");
            GameObject show = (GameObject)Instantiate(visualAchievement);
            show.transform.SetParent(GameObject.Find("AchievementEarnedCanvas").transform);
            show.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title;
            show.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = achievementsList[title].Desc;
            show.transform.GetChild(0).GetComponent<Image>().sprite = achievementsDoneSprites[achievementsList[title].SpriteIndex];
            show.transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(hideAchievement(show));

            saveAchievement(title, true);
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
        Debug.Log("Am here");
        foreach (var item in achievementsList)
        {
            Debug.Log(PlayerPrefs.GetInt(item.Key));
            if (PlayerPrefs.GetInt(item.Key) == 1)
            {
                Debug.Log("Is here");
                achievementsList[item.Value.Name].isNotUnlocked();
            }
        }

    }

    public IEnumerator hideAchievement(GameObject achievement)
    {
        //wait for three seconds before hiding achievement
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }


    public void createAchievement(string title, string desc, int spriteIndex) //,Sprite image)
    {
        //create new achievement
        GameObject achievementUI = (GameObject)Instantiate(achievmentPrefab);
        //add text to title and description
        achievementUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title;
        achievementUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = desc;

        //example of setting image
        achievementUI.transform.GetChild(0).GetComponent<Image>().sprite = achievementsNotDoneSprites[spriteIndex];

        //achievementsUIList.Add(achievementUI);

        //create achievement object to track if achievement is complete
        Achievement newAchievement = new Achievement(title, desc, spriteIndex, achievementUI);

        achievementsList.Add(title, newAchievement);

        //return achievement;
    }
}
