using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Core;

//clasa dla przycisku Lecimy gotować 
public class MyButton : MonoBehaviour
{
    public ToggleManeger toggleManager;
    public Licznik licznik; //zmienna liczniku
    public Awaria awaria;// zmienna awariji
    public int count = 0; // licznik podejść
    public bool animacja = false;//zmienna czy jest animacja
    

    public void cklick()//metoda kliku
    {

        if (licznik.licznikPoprzedni == 0)//sprawdzamy czy licznik jest 0
        {
            animacja = true;
            awaria.zablokowacAnimacja();

        }
        else {//jeśli nie to awaria 
            animacja = false;
            awaria.zablokowac();//blokujemy komponenty

        }

        

    }
    public void ToggleInteraction()//wyloncza aktywność componentu toggle
    {
        // yield return new WaitForSeconds(0.2f); // Dodatkowe opóźnienie po zakończeniu przesuwania obrazka
                                               // Wywołujemy naszą metodę, która ma zacząć pracować po zakończeniu przesuwania obrazka
                                               //awaria.odblokowacAnimacja(); // nie tutaj bo nasze togle jeście nie dodane do toggleListZaakceptowanych i tzeba żeby odblokować już po zapisaniu
                                               // licznik.textComponent.text = $"{licznik.licznikPoprzedni}";//zmieniamy licznik
                                               // Debug.Log("myList Count : " + toggleManager.myList.Count);

       // Tuple<int, Toggle, Image, IngredientType> pair = toggleManager.myList[0];
       // for (int i = 0; i < toggleManager.myList.Count; i++)//przecodzimy po liczcie tematów i 
       // {
        //    pair = toggleManager.myList[i];//bierzemo pare tego index
         
        //        Debug.Log(" pair.Item2 " + pair.Item2);
        //        pair.Item2.enabled = false;//robimy go nie actwnym żeby grać nie mógł wybierać go znów
            
             //   pair.Item3.enabled = true;//i robimy widocznym krzużyk
           //     Debug.Log(" pair.Item3 " + pair.Item3);
       // }
        count++;//zwiększamy licznik podejść
        toggleManager.toggleListZaakceptowanych.AddRange(toggleManager.typyList);//dodajemy wybrane togle do listy zaakceptowanych toggle
        toggleManager.toggleList.Clear();// robimy clear listy 
        toggleManager.typyList.Clear();// robimy clear listy 
        toggleManager.myList.Clear();
        if (toggleManager.toggleListZaakceptowanych.Count > 0)
        {

            for (int i = 0; i < toggleManager.toggleListAll.Count; i++) // przechodzimy po tablice wszystkich toglle i sprawdzamy czy te toggle nie są zaakceptowane
            {
                if (toggleManager.toggleListZaakceptowanych.Contains(toggleManager.toggleListAll[i].Item2))
                {
                    toggleManager.toggleListAll[i].Item1.enabled = false; // i robimy znów actywnymi
                   toggleManager.toggleListAll[i].Item3.enabled = true;
                }


            }

        }

        IngredientsHolder.ClearTypes();
        foreach (IngredientType type in toggleManager.toggleListZaakceptowanych)
        {
            Debug.Log(type);
            IngredientsHolder.AddType(type);
        }
        ServiceLocator.Get<IngredientsService>().saveIngredients(toggleManager.toggleListZaakceptowanych);
        awaria.odblokowacAnimacja();//odblokujemy componenty
    }
}
