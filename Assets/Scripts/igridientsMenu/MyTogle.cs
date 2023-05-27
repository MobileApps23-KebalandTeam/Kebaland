using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

// clasa dla pojedynczego podanego toggle 
//w toggleGroup zaznaczyłam Allow Switch off robi wszystkie nasze toglle niezaznaczonymi 
public class MyTogle : MonoBehaviour
{
    public Toggle toggle;// toggle do kturego przypisany metod
    public ToggleManeger toggleManager;//zmienna kontenera
    public Licznik licznik; // zmienna licznika
    public Image krzyzykMy; // zdjęcie krzyżyka
    public int temat = 0; // temat podanego toggl
    public ToggleGroup toggleGroup;  // podany toggleGroup do którego należy podany toggle  
    public Color selectedColorActivRGB;// color wybranego toggle
    public Color selectedColorNoActivRGB;// color nie wybranego toggle
    public MyButton countGame;//zmiena clasy MyButton 
    public IngredientType type;
    // Start jest wywoływany przed aktualizacją pierwszego updete
    void Start()
    {
        toggle = GetComponent<Toggle>();//pobiera component Toggle do którego jest przypisany skrypt
        //toggleManager.toggleListAll.Add(toggle,type);// dodaje do listy wszystkich toggle nasz pojedynczy toggle
      
        toggleManager.AddToggleType(toggle, type, krzyzykMy);
        Debug.Log("TOOOOOOOOOOOOOOOOOO" + toggle);
    }

    public void OnToggleValueChangedMeat()//metoda użyana przy kliku na toglle
    {
        if (LevelChoice.GetStartedLevel() == 0)//sprawdzamy czy to jest pierwszy wybur gracza
        {
            if (temat != toggleManager.toggleTemat)//sprawdzamy czy temat wybranego pojedynczego toggle nie jest taka sama jak i aktywna tema(tema poprzednio wybranego toggle)
            {
                toggleManager.toggleTemat = temat; // zmienaiamy aktwną teme
                toggleManager.toggleTypeActiv = type;
                bool numberExists = toggleManager.myList.Exists(item => item.Item1 == temat);//sprawdza czy temat już byl używany 
                if (numberExists)//jeśli tak
                {
                    // Zapisanie pary gdie temat jest równy tematu wybranego toggle 
                    Tuple<int, Toggle, Image, IngredientType> pair = toggleManager.myList[0];
                    int index = -1; // i szukamy index tego tematu
                    for (int i = 0; i < toggleManager.myList.Count; i++)
                    {
                        pair = toggleManager.myList[i];
                        if (pair.Item1 == temat)
                        {
                            index = i;
                            break;
                        }
                    }
  
                    if (toggle.isOn)//sprawdzamy czy wybrany toggle jest wlączony
                    {
                        //Debug.Log("Sprawdzamy czy Actywny item2 == togle" + (pair.Item2 != toggle));
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);//robimy actywnym i zmieniamy krzyżyk
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;//zmieniamy kolor toggl na wlączony
                        if (toggle != null && toggleManager != null)//jeśli toggle i toggleManażer nie są null to 
                        {
                            toggleManager.AddToggle(toggle,type);//dodajemy do tablicy wybranych toggle
                            licznik.Zmien(true); // i zmieniamy licznik (licznik zmniejsza się)
                        }
                        Debug.Log("Toggle jest włączonyE! " + toggle.name + "  " + toggleManager.toggleCounter);
                    }
                    else//jeśli toogle nie wlączony
                    {
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.RemoveToggle(toggle, type);//usuwamy z listy wybranych toglle
                            licznik.Zmien(false);//zmieniamy licznik(licznik zwiększa się)
                        }
                        Debug.Log("Toggle jest wyłączonyE!");
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;//zmieniamy kolor na nie wlączony


                    }
                    Tuple<int, Toggle, Image, IngredientType> firstPair = toggleManager.myList[index];//pobiera pare podanego indeksu tematu 

                    firstPair = new Tuple<int, Toggle, Image, IngredientType>(temat, toggleManager.togleActivMeat, toggleManager.krzyzykActiv, type);// modyfikacja danych pary nowym wybranym toggle tego tematu i jego krzyżykiem  

                    toggleManager.myList[index] = firstPair;  // Aktualizuj parę w liście
                }
                else //jeśli temat był wybrany pierwszy raz
                {
                    if (toggle.isOn)
                    {
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.AddToggle(toggle, type);
                            licznik.Zmien(true);
                        }
                        Debug.Log("Toggle jest włączony3! " + toggle.name + "  " + toggleManager.toggleCounter);
                    }
                    else //MOŻE NIE POTRZEBNE BO JEŚLI TEMAT JEST WYBRANY PIERWSZY RAZ TO ZAWSZE BĘDZIE WŁĄCZONYM
                    {
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.RemoveToggle(toggle, type);
                            licznik.Zmien(false);
                        }
                        Debug.Log("Toggle jest wyłączony3!");
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    }
                    toggleManager.AddTemat(temat, toggleManager.togleActivMeat, toggleManager.krzyzykActiv, type);//dodanie tematu aktywnego toggle i krzyżyka do listy tematów 
                }



            }
            else // jeśli teamat nie zmienial się (wybrany toggle jest z tego samego tematu)
            {
                //szukamy indeks tego tematu i pare 
                Tuple<int, Toggle, Image, IngredientType>  pair = toggleManager.myList[0];
                int index = -1;
                for (int i = 0; i < toggleManager.myList.Count; i++)
                {
                    pair = toggleManager.myList[i];
                    if (pair.Item1 == temat)
                    {
                        index = i;
                        break;
                    }
                }
                if (toggle.isOn)
                {
                    Debug.Log("4Sprawdzamy czy Actywny item4 == togle " + (pair.Item2 != toggle) + " " + pair.Item2);
                    if (pair.Item2 != toggle)// sprawdzamy czy zapisany toggle tego tematu jest wybranym toglle 
                    {//jeśli nie (i toggl jest inny)

                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);//robimy actywnym 
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.AddToggle(toggle, type);
                            licznik.Zmien(true);
                        }
                        Debug.Log("Toggle jest włączony4! " + toggle.name + "  " + toggleManager.toggleCounter);

                    }
                    else //jeśli tak to 
                    {
                        Debug.Log("Count! " + toggle.name + "  " + toggleManager.toggleCounter);
                        licznik.Zmien(true);
                        toggleManager.AddToggle(toggle, type);
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);//robimy actywnym 
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        toggleManager.toggleCounter++;//dodajemy do licznika 1
                    }
                }
                else
                {
                    if (toggleManager.toggleCounter <= 0)//sprawdzamy jeśli toggle jest wybrany i wyłączony więcej niż 0 MOZE NIE TRZEBA SPRAWDZAĆ!
                    {

                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.RemoveToggle(toggle, type);
                            licznik.Zmien(false);
                        }
                        Debug.Log("Toggle jest wyłączony4!" + toggle.name + "  " + toggleManager.toggleCounter);

                        // Wykonywanie kodu, gdy Toggle jest wyłączony (off).
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    }
                    else
                    {
                        licznik.Zmien(false);
                        toggleManager.RemoveToggle(toggle, type);
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    }

                    toggleManager.toggleCounter = 0;//zerujemy licznik klików


                }

                Tuple<int, Toggle, Image, IngredientType> firstPair = toggleManager.myList[index];

                // Zmodyfikuj dane pary
                firstPair = new Tuple<int, Toggle, Image, IngredientType>(temat, toggleManager.togleActivMeat, toggleManager.krzyzykActiv, type);

                // Aktualizuj parę w liście
                toggleManager.myList[index] = firstPair;

            }
        }
        else //Jeśli to nie pierwszy wybur 
        {
            toggleGroup.enabled = false;//robimy togleGroup nie actywnym żeby moglibyśmy wybierać więcej niż jeden toggle z kategoriji
            Debug.Log("TOOOGGG GROUP " + (toggleGroup.enabled));
            if (licznik.licznikPoprzedni > 0)//sprawdzamy licznik jeśli on jest więkzsy za 0 możmy wybierać różne toggle
            {
                if (toggle.isOn)
                {
                    toggleManager.AddToggle(toggle, type);
                    licznik.Zmien(true);
                    toggle.GetComponent<Image>().color = selectedColorActivRGB;
                    toggleManager.AddTemat(temat, toggle, krzyzykMy, type);
                }
                else
                {
                    toggleManager.RemoveToggle(toggle, type);
                    licznik.Zmien(false);
                    toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    Tuple<int, Toggle, Image, IngredientType> pair = toggleManager.myList[0];
                    int index = -1;
                    for (int i = 0; i < toggleManager.myList.Count; i++)
                    {
                        pair = toggleManager.myList[i];
                        if (pair.Item2 == toggle)
                        {
                            index = i;
                            break;
                        }
                    }
                    toggleManager.RemoveTemat(index);
                }
                Debug.Log("TOOOGGG1 " + toggleManager.myList.Count);


            }
            else {//jeśli licznik jest 0 to 
               // bool numberExists = toggleManager.myList.Exists(item => item.Item2 == toggle);//sprawdza czy temat już byl używany 
                if (toggleManager.toggleList.Contains(toggle))//jeśli toggle już należy do listy wybranych toggle to 
                {
                   
                    if (toggle.isOn)//MOŻE NIE TRZEBA BO TOGLE KTÓRY NALEŻY DO LISTY WYBRANYCH TOGGLE JEST JUŻ ACTIVE
                    {
                        toggleManager.AddToggle(toggle, type);
                        licznik.Zmien(true);
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        toggleManager.AddTemat(temat, toggle, krzyzykMy, type);
                    }
                    else
                    {
                        toggleManager.RemoveToggle(toggle, type);//usuwamy toggle z listy
                        licznik.Zmien(false);//zmieniamy licznik (zwiększamy)
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                        Tuple<int, Toggle, Image, IngredientType> pair = toggleManager.myList[0];
                        int index = -1;
                        for (int i = 0; i < toggleManager.myList.Count; i++)//sukamy index gdzie jest wybrany toggle 
                        {
                            pair = toggleManager.myList[i];
                            if (pair.Item2 == toggle)
                            {
                                index = i;
                                break;
                            }
                        }
                        toggleManager.RemoveTemat(index);//i usuwamy z listy tematów 
                    }
                    Debug.Log("TOOOGGG2 " + toggleManager.myList.Count);

                }
                else {//jeśli nie to toggle zostaje się wylączonym
                    toggle.isOn = false;
                }
                    
            }
            
        }
    }
}
