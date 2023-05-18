using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsScript : MonoBehaviour
{

    public float time = 5 * 60;
    public GameObject pointsObject;
    public GameObject timeObject;

    public EndGameScript endGameScript;

    public Manager manager;

    private static GameObject points;

    private static int sumPoints;
    private static int reqPoints = 10;
    private static int sumOrders;

    private void Start()
    {
        points = pointsObject;
        setPoints(0);
        sumOrders = 0;
    }

    void Update()
    {
        if (manager.IsEndGame()) return;
        time = max(time - Time.deltaTime, 0f);
        if (time <= 0)
        {
            manager.EndGame();
            endGameScript.Show(sumPoints, reqPoints, sumOrders);
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

    public static void AddPoints(int points)
    {
        setPoints(sumPoints + points);
    }

    public static void setPoints(int points)
    {
        sumPoints = points;
        StatisticsScript.points.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Punkty: " + sumPoints + "/" + reqPoints;
    }

    public static void setRequieredPoints(int points)
    {
        reqPoints = points;
    }

    public static int getRequiredPoints()
    {
        return reqPoints;
    }

    public static void AddOrder()
    {
        sumOrders++;
    }

    private float max(float a, float b)
    {
        return ((a < b) ? b : a); 
    }

}
