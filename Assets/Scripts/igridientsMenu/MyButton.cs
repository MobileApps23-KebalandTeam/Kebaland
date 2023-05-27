using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

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
            if (count == 0)//jeśli to drugie podejście 
            {
                licznik.licznikPoprzedni = 2;
            }
            else if (count >= 1)
            {
                licznik.licznikPoprzedni = 1;
            }
        
            animacja = true;
            awaria.zablokowacAnimacja();

        }
        else {//jeśli nie to awaria 
            animacja = false;
            awaria.zablokowac();//blokujemy komponenty

        }

        

    }
    public IEnumerator ToggleInteraction()//wyloncza aktywność componentu toggle
    {
        yield return new WaitForSeconds(0.2f); // Dodatkowe opóźnienie po zakończeniu przesuwania obrazka
                                               // Wywołujemy naszą metodę, która ma zacząć pracować po zakończeniu przesuwania obrazka
      //awaria.odblokowacAnimacja(); // nie tutaj bo nasze togle jeście nie dodane do toggleListZaakceptowanych i tzeba żeby odblokować już po zapisaniu
        licznik.textComponent.text = $"{licznik.licznikPoprzedni}";//zmieniamy licznik
       // Debug.Log("myList Count : " + toggleManager.myList.Count);

        Tuple<int, Toggle, Image> pair = toggleManager.myList[0];
        for (int i = 0; i < toggleManager.myList.Count; i++)//przecodzimy po liczcie tematów i 
        {
            pair = toggleManager.myList[i];//bierzemo pare tego index
         
                Debug.Log(" pair.Item2 " + pair.Item2);
                pair.Item2.enabled = false;//robimy go nie actwnym żeby grać nie mógł wybierać go znów
            
                pair.Item3.enabled = true;//i robimy widocznym krzużyk
                Debug.Log(" pair.Item3 " + pair.Item3);
        }
        count++;//zwiększamy licznik podejść
        toggleManager.toggleListZaakceptowanych.AddRange(toggleManager.toggleList);//dodajemy wybrane togle do listy zaakceptowanych toggle
        toggleManager.toggleList.Clear();// robimy clear listy 
        toggleManager.myList.Clear();
        awaria.odblokowacAnimacja();//odblokujemy componenty

    }
}
