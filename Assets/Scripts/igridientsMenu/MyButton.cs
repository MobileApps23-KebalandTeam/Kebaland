using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


public class MyButton : MonoBehaviour
{
    public ToggleManeger toggleManager;
    public Licznik licznik;
    public Awaria awaria;
    public int count = 0;
    // Start is called before the first frame update
    public void cklick()
    {


        if (licznik.licznikPoprzedni == 0)
        {
            if (count == 0)
            {
                licznik.licznikPoprzedni = 2;
            }
            else if (count >= 1)
            {
                licznik.licznikPoprzedni = 1;
            }
            //else if (count == 2)
          //  {
           //     licznik.licznikPoprzedni = 1;
           // }
            licznik.textComponent.text = $"{licznik.licznikPoprzedni}";
            DisableToggleInteraction();
        }
        else {
            awaria.zablokowac();

        }

        //DisableToggleInteraction();

    }
    public void DisableToggleInteraction()//wyloncza aktywność componentu toggle
    {
        Debug.Log("MYYYYYYYYYYYYYYYY " + toggleManager.myList.Count);
        Tuple<int, Toggle, Image> pair = toggleManager.myList[0];
        for (int i = 0; i < toggleManager.myList.Count; i++)
        {
            pair = toggleManager.myList[i];
           // if (pair.Item1 == temat)
          //  {
                //pair.Item2.interactable = false;
                Debug.Log(" pair.Item2 " + pair.Item2);
                pair.Item2.enabled = false;
            //if (pair.Item3 != null) {
                pair.Item3.enabled = true;
                Debug.Log(" pair.Item3 " + pair.Item3);
         //   }
           
            //toggleObject.SetActive(false);
            // }
        }
        count++;
        toggleManager.toggleListZaakceptowanych.AddRange(toggleManager.toggleList);
        toggleManager.toggleList.Clear();
        toggleManager.myList.Clear();
        Debug.Log("MYYYYYYYYYYYYYYYYC " + toggleManager.myList.Count);

    }
}
