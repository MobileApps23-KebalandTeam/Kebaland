using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

public class Awaria : MonoBehaviour
{
    //public MyButton myButton;
    public ToggleManeger toggleManager; // zmienna obiektu managera Toggles
    public GameObject objectToDisable; // zmienna obiektu awaria
    public ScrollRect scrollRect; // zmienna
    public bool awariaIF = false;
    // public EventTrigger eventTrigger;
    public Button button1;
    public void cklick()
    {
        objectToDisable.SetActive(false);//robi nasz obiekt nie aktywnym 
        scrollRect.enabled = true;//robi nasz scrollRect aktywnym 
        // eventTrigger.enabled = true;
        awariaIF = false; // zmienna booloa która pozwała sprawdzić czy awaria jest czy nie
        button1.enabled = true; 
        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)
        {
            if (!(toggleManager.toggleListZaakceptowanych.Contains(toggleManager.toggleListAll[i]))) {
                toggleManager.toggleListAll[i].enabled = true;
            }
           

        }
    }
    public void zablokowac()
    {
        scrollRect.enabled = false;
        //eventTrigger.enabled = false;
        button1.enabled = false;
        awariaIF = true;
        objectToDisable.SetActive(true);
 
        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)
        {
            toggleManager.toggleListAll[i].enabled = false;

        }
    }

    public void zablokowacAnimacja()
    {
        scrollRect.enabled = false;
        //eventTrigger.enabled = false;
        button1.enabled = false;
        awariaIF = true;
        //objectToDisable.SetActive(true);

        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)
        {
            toggleManager.toggleListAll[i].enabled = false;

        }
    }
    public void odblokowacAnimacja()
    {
       // objectToDisable.SetActive(false);//robi nasz obiekt nie aktywnym 
        scrollRect.enabled = true;//robi nasz scrollRect aktywnym 
        // eventTrigger.enabled = true;
        awariaIF = false; // zmienna booloa która pozwała sprawdzić czy awaria jest czy nie
        button1.enabled = true;
        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)
        {
            if (!(toggleManager.toggleListZaakceptowanych.Contains(toggleManager.toggleListAll[i])))
            {
                toggleManager.toggleListAll[i].enabled = true;
            }


        }
    }
}
