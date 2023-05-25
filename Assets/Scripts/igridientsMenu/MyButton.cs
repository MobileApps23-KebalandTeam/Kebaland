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
    public bool animacja = false;
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
            animacja = true;
            awaria.zablokowacAnimacja();

        }
        else {
            animacja = false;
            awaria.zablokowac();

        }

        //DisableToggleInteraction();

    }
    public IEnumerator DisableToggleInteraction()//wyloncza aktywność componentu toggle
    {
        yield return new WaitForSeconds(0.5f); // Dodatkowe opóźnienie po zakończeniu przesuwania obrazka
                                               // Wywołujemy naszą metodę, która ma zacząć pracować po zakończeniu przesuwania obrazka
      //awaria.odblokowacAnimacja(); // nie tutaj bo nasze togle jeście nie dodane do toggleListZaakceptowanych i tzeba żeby odblokować już po zapisaniu
        licznik.textComponent.text = $"{licznik.licznikPoprzedni}";
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
        awaria.odblokowacAnimacja();

    }
}
