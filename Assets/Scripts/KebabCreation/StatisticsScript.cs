using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsScript : MonoBehaviour
{

    public float time = 5 * 60;
    public GameObject pointsObject;
    public GameObject timeObject;

    private static GameObject points;

    private static int sumPoints;

    private void Start()
    {
        points = pointsObject;
        setPoints(0);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Debug.Log("Czas minal!");
        }
        else refreshTime();
    }

    public void refreshTime()
    {
        int t = (int)time;
        string min = ((t / 60 < 10) ? "0" : "") + (t / 60);
        string sec = ((t % 60 < 10) ? "0" : "") + (t % 60);
        timeObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Czas: " + min + ":" + sec;
    }

    public static void addPoints(int points)
    {
        setPoints(sumPoints + points);
    }

    public static void setPoints(int points)
    {
        sumPoints = points;
        StatisticsScript.points.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Punkty: " + sumPoints;
    }

}
