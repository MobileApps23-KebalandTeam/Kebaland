using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

//class konteiner dla wszystkich toggle żeby mieli jedne wspólne listy dla toggle
public class ToggleManeger : MonoBehaviour
{
    public List<Tuple<int, Toggle, Image>> myList = new List<Tuple<int, Toggle, Image>>(); //lista tema, actywnych/wybranych/wlączonych toggle , krzyżyk tego togla
    public List<Toggle>toggleList = new List<Toggle>();// lista actywnych/wybranych/wlączonych toggle 
    public List<Toggle> toggleListAll = new List<Toggle>();// lista wszystkich toggle dla zmianu stanu przy (awariji i animacji)
    public List<Toggle> toggleListZaakceptowanych = new List<Toggle>();// lista zaakceptowanych toggle (wybrane toggle po każdym level)
    public Toggle togleActivMeat; // actywny wybrany toggle (ostatni wybrany)
    public Image krzyzykActiv; // krzyżyk actywnego toogle
    public int toggleCounter = 0; // licznik toglle to zmienne wykorzystujemy gdy możemy wybrać tylko jeden igredient z jednej katygoriji (wykorzystamy przy drugim kliku na już wybrany toggle)
    public int toggleTemat = 0; // wybrany temat toggle

    public void AddToggle(Toggle toggle)//metoda dodaje do listy toggle wybrany actywny toggle
    {
        toggleList.Add(toggle);
    }
    public void AddTemat(int temat,Toggle toggleA, Image krzyzyk)//metoda dodaje do listy myList temat i actywny toggle tego tematu i krzyżyk tego toggla
    {
        myList.Add(new Tuple<int, Toggle, Image>(temat, toggleA, krzyzyk));
    }
    public void RemoveTemat(int index)// usuwa temat z listy myList
    {
        myList.RemoveAt(index);
    }
    public void SelectToggleMeat(Toggle toggle,Image krzyzyk)//zmienia actywny wybrany toggle i jego krzyżyk
    {
        togleActivMeat = toggle;
        krzyzykActiv = krzyzyk;
    }
    public void RemoveToggle(Toggle toggle)//usuwa z listy wybranych i aktywnych toggle podany toggle 
    {
        toggleList.Remove(toggle);
    }
}
