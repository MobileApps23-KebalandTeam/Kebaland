using System;
using System.Collections.Generic;
using System.Globalization;
using Core;
using Model;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

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
            s += getEntryText(entry.LevelNumber, entry.passed, entry.mode, entry.first_time);
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

    private static string clickerText(int level)
    {
        switch (level)
        {
            case 0: return "Po ciężkich starciach armia została rozgromiona\n";
            case 1: return "Przeciwnik ucieka\n";
            case 2: return "Agresywny kebab\n";
            default: return "Ostry sos\n";
        }
    }

    private static string getEntryText(int level, bool passed, LevelType mode, bool first_time)
    {
        switch (mode)
        {
            case LevelType.CLICKER: return getClickerText(level, passed, first_time);
            case LevelType.KEBAB: return getKebabText(level, passed, first_time);
            default: return "";
        }
    }

    private static string getClickerText(int level, bool passed, bool first_time)
    {
        switch (passed)
        {
            case true:
                switch (first_time)
                {
                    case true: return clickerText(level);
                    case false: return passedLevelAgain[Random.Range(0, passedLevelAgain.Count)];
                }
            case false: return failedClicker[Random.Range(0, failedClicker.Count)];
        }
    }

    private static string getKebabText(int level, bool passed, bool first_time)
    {
        switch (passed)
        {
            case true:
                switch (first_time)
                {
                    case true: return clickerText(level);
                    case false: return passedClickerAgain[Random.Range(0, passedClickerAgain.Count)];
                }
            case false: return failedKebab[Random.Range(0, failedKebab.Count)];
        }
    }

    private static List<string> failedKebab = new List<string>
    {
        "Mieszkańcy planety byli zbyt głodni\n",
        "Nasze mięso było surowe\n",
        "Sałata nam spleśniała\n"
    };

    private static List<string> failedClicker = new List<string>
    {
        "Przeciwnik był zbyt silny, musimy uciekać\n",
        "Trafili nas! Mayday! Mayday!\n",
        "Strzelają w nas taco, musimy uciekać\n",
        "Mają guacamole! Ewakuacja!!!\n",
        "Odwrót!!!"
    };

    private static List<string> passedLevelAgain = new List<string>
    {
        "Mamy chyba za niskie ceny\n",
    };

    private static List<string> passedClickerAgain = new List<string>
    {
        "Aż za łatwo się z nimi wygrywa\n",
        "Czy awokado jest dobrą podpałką pod rożno?\n",
    };
}