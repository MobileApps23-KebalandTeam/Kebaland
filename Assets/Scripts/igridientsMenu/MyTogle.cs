using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class MyTogle : MonoBehaviour
{
    //public GameObject toggleObject;
    public Toggle toggle;
    public ToggleManeger toggleManager;
    public Licznik licznik;
    public Image krzyzykMy;
    public int temat = 0;
    public ToggleGroup toggleGroup;
    public Color selectedColorActivRGB;
    //public Transform toggleContainer;
    public Color selectedColorNoActivRGB;
    public MyButton countGame;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        // Pobieranie komponentu ToggleGroup z tego samego obiektu
        //toggleGroup = GetComponent<ToggleGroup>();
        toggleManager.toggleListAll.Add(toggle);
    }
    public void OnToggleValueChangedMeat()
    {
        if (countGame.count == 0)
        {
            if (temat != toggleManager.toggleTemat)
            {
                //toggleManager.toggleCounter = 0;
                toggleManager.toggleTemat = temat;
                bool numberExists = toggleManager.myList.Exists(item => item.Item1 == temat);//sprawdza czy temat już byl używany 
                if (numberExists)
                {// Zapisanie pary, gdzie liczba jest równa 1

                    // Zapisanie indeksu pary, gdzie liczba jest równa 1
                    Tuple<int, Toggle, Image> pair = toggleManager.myList[0];
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
                    // Tuple<int, Toggle, Toggle> pair = myLsit.Find(t => t.Item1 == temat);
                    if (toggle.isOn)
                    {
                        Debug.Log("Sprawdzamy czy Actywny item2 == togle" + (pair.Item2 != toggle));
                        // if (pair.Item2 != toggle)
                        //{
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);//robimy actywnym 
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.AddToggle(toggle);
                            licznik.Zmien(true);
                        }
                        Debug.Log("Toggle jest włączonyE! " + toggle.name + "  " + toggleManager.toggleCounter);

                        //}



                    }
                    else
                    {

                        toggleManager.SelectPoprzedniToggleMeat(toggle);
                        //toggleManager.toggleCounter = 0;
                        // if (toggleManager.toggleCounter <= 1)
                        // {
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.RemoveToggle(toggle);
                            licznik.Zmien(false);
                        }
                        Debug.Log("Toggle jest wyłączonyE!");
                        // }
                        // Wykonywanie kodu, gdy Toggle jest wyłączony (off).
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;


                    }
                    Tuple<int, Toggle, Image> firstPair = toggleManager.myList[index];

                    // Zmodyfikuj dane pary
                    firstPair = new Tuple<int, Toggle, Image>(temat, toggleManager.togleActivMeat, toggleManager.krzyzykActiv);

                    // Aktualizuj parę w liście
                    toggleManager.myList[index] = firstPair;
                }
                else
                {
                    if (toggle.isOn)
                    {
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.AddToggle(toggle);
                            licznik.Zmien(true);
                        }
                        Debug.Log("Toggle jest włączony3! " + toggle.name + "  " + toggleManager.toggleCounter);
                    }
                    else
                    {
                        toggleManager.SelectPoprzedniToggleMeat(toggle);
                        // toggleManager.toggleCounter = 0;
                        // if (toggleManager.toggleCounter <= 1)
                        // {
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.RemoveToggle(toggle);
                            licznik.Zmien(false);
                        }
                        Debug.Log("Toggle jest wyłączony3!");
                        // }
                        // Wykonywanie kodu, gdy Toggle jest wyłączony (off).
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;


                    }
                    toggleManager.AddTemat(temat, toggleManager.togleActivMeat, toggleManager.krzyzykActiv);
                }



            }
            else
            {
                Tuple<int, Toggle, Image> pair = toggleManager.myList[0];
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
                    if (pair.Item2 != toggle)
                    {
                        // toggleManager.toggleCounter = 0;
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);//robimy actywnym 
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.AddToggle(toggle);
                            licznik.Zmien(true);
                        }
                        Debug.Log("Toggle jest włączony4! " + toggle.name + "  " + toggleManager.toggleCounter);

                    }
                    else
                    {
                        Debug.Log("Count! " + toggle.name + "  " + toggleManager.toggleCounter);
                        licznik.Zmien(true);
                        toggleManager.AddToggle(toggle);
                        toggleManager.SelectToggleMeat(toggle, krzyzykMy);//robimy actywnym 
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        toggleManager.toggleCounter++;
                    }
                }
                else
                {
                    toggleManager.SelectPoprzedniToggleMeat(toggle);
                    // toggleManager.toggleCounter = 0;
                    if (toggleManager.toggleCounter <= 0)
                    {

                        if (toggle != null && toggleManager != null)
                        {
                            toggleManager.RemoveToggle(toggle);
                            licznik.Zmien(false);
                        }
                        Debug.Log("Toggle jest wyłączony4!" + toggle.name + "  " + toggleManager.toggleCounter);

                        // Wykonywanie kodu, gdy Toggle jest wyłączony (off).
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    }
                    else
                    {
                        licznik.Zmien(false);
                        toggleManager.RemoveToggle(toggle);
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    }

                    toggleManager.toggleCounter = 0;


                }
                //toggleManager.AddTemat(temat, toggleManager.togleActivMeat, toggleManager.toglePoprzedniMeat);
                Tuple<int, Toggle, Image> firstPair = toggleManager.myList[index];

                // Zmodyfikuj dane pary
                firstPair = new Tuple<int, Toggle, Image>(temat, toggleManager.togleActivMeat, toggleManager.krzyzykActiv);

                // Aktualizuj parę w liście
                toggleManager.myList[index] = firstPair;

                // if (licznik.licznikPoprzedni == 0) { DisableToggleInteraction(); }

            }


        }
        else
        {
            toggleGroup.enabled = false;
            Debug.Log("TOOOGGG GROUP " + (toggleGroup.enabled));
            if (licznik.licznikPoprzedni > 0)
            {
                if (toggle.isOn)
                {
                    toggleManager.AddToggle(toggle);
                    licznik.Zmien(true);
                    toggle.GetComponent<Image>().color = selectedColorActivRGB;
                    toggleManager.AddTemat(temat, toggle, krzyzykMy);
                }
                else
                {
                    toggleManager.RemoveToggle(toggle);
                    licznik.Zmien(false);
                    toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                    Tuple<int, Toggle, Image> pair = toggleManager.myList[0];
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
            else {
               // bool numberExists = toggleManager.myList.Exists(item => item.Item2 == toggle);//sprawdza czy temat już byl używany 
                if (toggleManager.toggleList.Contains(toggle))
                {
                   
                    if (toggle.isOn)
                    {
                        toggleManager.AddToggle(toggle);
                        licznik.Zmien(true);
                        toggle.GetComponent<Image>().color = selectedColorActivRGB;
                        toggleManager.AddTemat(temat, toggle, krzyzykMy);
                    }
                    else
                    {
                        toggleManager.RemoveToggle(toggle);
                        licznik.Zmien(false);
                        toggle.GetComponent<Image>().color = selectedColorNoActivRGB;
                        Tuple<int, Toggle, Image> pair = toggleManager.myList[0];
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
                    Debug.Log("TOOOGGG2 " + toggleManager.myList.Count);

                }
                else {
                    toggle.isOn = false;
                }
                    
            }
            
        }
    }
}
