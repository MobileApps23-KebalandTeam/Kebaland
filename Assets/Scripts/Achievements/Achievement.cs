using UnityEngine;
using UnityEngine.UI;

public class Achievement
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string desc;

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }
    private bool unlocked;

    public bool Unlocked
    {
        get { return unlocked; }
        set { unlocked = value; }
    }
    private int spriteIndex;

    public int SpriteIndex
    {
        get { return spriteIndex; }
        set { spriteIndex = value; }
    }

    private GameObject referenceObject;

    public GameObject ReferenceObject
    {
        get { return referenceObject; }
        set { referenceObject = value; }
    }

    public Achievement(string name, string desc, int spriteIndex, GameObject referenceObject)
    {
        this.name = name;
        this.desc = desc;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.referenceObject = referenceObject;
    }

    public bool isNotUnlocked()
    {
        if (!unlocked)
        {
            unlocked = true;
            Debug.Log("spriteIndex: " + spriteIndex);
            if (AchievementManager.Instance.mainMenuScreen == true) { referenceObject.transform.GetChild(0).GetComponent<Image>().sprite = AchievementManager.Instance.achievementsDoneSprites[spriteIndex]; }
            return true;
        }
        return false;
    }
}
