using System;
using System.Collections.Generic;
using System.Globalization;
using Core;
using Model;
using TMPro;
using UnityEngine;

public class LogBookMenu : MonoBehaviour
{
    [SerializeField] GameObject logbookPanel;

    [SerializeField] private GameObject _textMeshPro;

    public void Exit()
    {
        logbookPanel.SetActive(false);
    }

    public void Show()
    {
        logbookPanel.SetActive(true);
        SetText();
    }

    public void SetText()
    {
        _textMeshPro.GetComponent<TextMeshProUGUI>().text = getLogbookText();
    }

    private string getLogbookText()
    {
        string s = "";
        foreach (var entry in getLogbook())
        {
            s += levelName(entry.LevelNumber);
            s += "\n";
            s += dateTime(entry.passedTime);
            s += "\n";
            s += levelText(entry.LevelNumber);
            s += "\n";
            s += "***************\n\n";
        }

        return s;
    }

    private List<MLogbookEntry> getLogbook()
    {
        return ServiceLocator.Get<LogbookService>().GetLogbook();
    }

    private string dateTime(long ticks)
    {
        DateTime k = new DateTime(ticks);
        return k.ToString("dd MMMM yyyy HH:mm", CultureInfo.CreateSpecificCulture("pl-PL"));
    }

    private static string levelName(int level)
    {
        switch (level)
        {
            case 0: return "Tatooine";
            case 1: return "Mars";
            case 2: return "Earth";
            default: return "Moon";
        }
    }
    
    private static string levelText(int level)
    {
        switch (level)
        {
            case 0: return "Wygrałeś z Meksykiem\n";
            case 1: return "Odbiłeś Teksas\n";
            case 2: return "Taco wybucha\n";
            default: return "Kapelusze z głów\n";
        }
    }
}
