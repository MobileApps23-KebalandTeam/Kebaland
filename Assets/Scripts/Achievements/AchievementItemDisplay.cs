using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AchievementItemDisplay : MonoBehaviour
{
    public TextMeshProUGUI achDesc;
    public Image achIcon;
    public AchievementItem achievement;

    // Start is called before the first frame update
    void Start()
    {
        if (achievement != null) Prime(achievement);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Prime(AchievementItem achievement)
    {
        this.achievement = achievement;
        if (achDesc != null)
        {
            achDesc.text = achievement.achDesc;
        }
        if (achIcon != null)
        {
            if (achievement.completed)
            {
                achIcon.sprite = achievement.completedAch;
            }
            else
            {
                achIcon.sprite = achievement.uncompletedAch;
            }

        }
    }
}
