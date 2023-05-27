using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

//class konteiner dla wszystkich toggle żeby mieli jedne wspólne listy dla toggle
public class ToggleManeger : MonoBehaviour
{
    public List<Tuple<int, Toggle, Image, IngredientType>> myList = new List<Tuple<int, Toggle, Image, IngredientType>>(); //lista tema, actywnych/wybranych/wlączonych toggle , krzyżyk tego togla
    public List<Toggle>toggleList = new List<Toggle>();// lista actywnych/wybranych/wlączonych toggle 
    public List<IngredientType> typyList = new List<IngredientType>();
    public List<Tuple<Toggle, IngredientType, Image>> toggleListAll = new List<Tuple< Toggle,IngredientType, Image>>();// lista wszystkich toggle dla zmianu stanu przy (awariji i animacji)
    public List<IngredientType> toggleListZaakceptowanych = new List<IngredientType>();// lista zaakceptowanych toggle (wybrane toggle po każdym level)
    public Toggle togleActivMeat; // actywny wybrany toggle (ostatni wybrany)
    public Image krzyzykActiv; // krzyżyk actywnego toogle
    public int toggleCounter = 0; // licznik toglle to zmienne wykorzystujemy gdy możemy wybrać tylko jeden igredient z jednej katygoriji (wykorzystamy przy drugim kliku na już wybrany toggle)
    public int toggleTemat = 0; // wybrany temat toggle
    public Color selectedColorActivRGB;
    public IngredientType toggleTypeActiv;

    public void wykorzystane()
    {
        Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@ " + toggleListAll.Count);
        if (toggleListZaakceptowanych.Count > 0) {

            for (int i = 0; i < toggleListAll.Count; i++) // przechodzimy po tablice wszystkich toglle i sprawdzamy czy te toggle nie są zaakceptowane
            {
                if ((toggleListZaakceptowanych.Contains(toggleListAll[i].Item2)))
                {
                    toggleListAll[i].Item1.GetComponent<Image>().color = selectedColorActivRGB;
                    toggleListAll[i].Item1.enabled = false; // i robimy znów actywnymi
                    toggleListAll[i].Item3.enabled = true;
                }


            }

        }
       
    }

    public void AddToggle(Toggle toggle, IngredientType type)//metoda dodaje do listy toggle wybrany actywny toggle
    {
        toggleList.Add(toggle);
        typyList.Add(type);

    }
    public void AddTemat(int temat,Toggle toggleA, Image krzyzyk, IngredientType type)//metoda dodaje do listy myList temat i actywny toggle tego tematu i krzyżyk tego toggla
    {
        myList.Add(new Tuple<int, Toggle, Image, IngredientType>(temat, toggleA, krzyzyk, type));
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
    public void RemoveToggle(Toggle toggle, IngredientType type)//usuwa z listy wybranych i aktywnych toggle podany toggle 
    {
        toggleList.Remove(toggle);
        typyList.Remove(type);
    }
    public void AddToggleType( Toggle toggleA, IngredientType type, Image krzyzyk)
    {
        toggleListAll.Add(new Tuple<Toggle, IngredientType,Image>(toggleA, type, krzyzyk));
    }
}
