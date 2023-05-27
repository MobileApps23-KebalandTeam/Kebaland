using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

//class Licznik aktualizuje liczbe igresientów które grać może wybrać
public class Licznik : MonoBehaviour
{
    public Text textComponent;//tekst licznika
    public ToggleManeger toggleManager;// toggle  manager (Contener wszystkich toggle)
    public int licznikPoprzedni;// licznik igredientów
   
    void Start()//metoda przy urachomieniu sceny
    {
        textComponent = GetComponent<Text>();//pobiera component text 
        licznikPoprzedni = 4; //początkowa liczba igredientów
    }

    public void Zmien(bool wybur)//metoda która zmienia liczbe igradientów przy wybieraniu
        // wybur - czy jest włączony toggle czy nie
    {
        if (toggleManager != null)
        {
            //Debug.Log("Liczba wybranych elementów: "+toggleManager.toggleList.Count);
            if (wybur)//jeśli toggle jest wybrany
            {
                    licznikPoprzedni = licznikPoprzedni - 1;
                //textComponent.text = $"{licznikPoprzedni - toggleManager.toggleList.Count}";
                //   Debug.Log("Licznik odjąć:  "  + (licznikPoprzedni - toggleManager.toggleList.Count));
                textComponent.text = $"{licznikPoprzedni}";//zmienia text licznika na aktóalnu liczbu igredientów
               Debug.Log("Licznik odjąć:  " + licznikPoprzedni);
            }
            else {
                    licznikPoprzedni = licznikPoprzedni + 1;
               Debug.Log("Licznik dodaj:  " + licznikPoprzedni);
               // Debug.Log("BBB " + (licznikPoprzedni - toggleManager.toggleList.Count));
               // textComponent.text = $"{licznikPoprzedni - toggleManager.toggleList.Count}";
               textComponent.text = $"{licznikPoprzedni}";
             }
            
        }
    }
}

