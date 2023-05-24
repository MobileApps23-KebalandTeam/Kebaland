using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class ToggleManeger : MonoBehaviour
{
    public List<Tuple<int, Toggle, Image>> myList = new List<Tuple<int, Toggle, Image>>();
    public List<Toggle>toggleList = new List<Toggle>() ;
    public List<Toggle> toggleListAll = new List<Toggle>();
    public List<Toggle> toggleListZaakceptowanych = new List<Toggle>();
    public Toggle togleActivMeat;
    public Toggle toglePoprzedniMeat;
    public Image krzyzykActiv;
    public int toggleCounter = 0;
    public int toggleTemat = 0;

    public void AddToggle(Toggle toggle)
    {
        toggleList.Add(toggle);
    }
    public void AddTemat(int temat,Toggle toggleA, Image krzyzyk)
    {
        myList.Add(new Tuple<int, Toggle, Image>(temat, toggleA, krzyzyk));
    }
    public void RemoveTemat(int index)
    {
        myList.RemoveAt(index);
    }
    public void SelectToggleMeat(Toggle toggle,Image krzyzyk)
    {
        togleActivMeat = toggle;
        krzyzykActiv = krzyzyk;
    }
     public void SelectPoprzedniToggleMeat(Toggle toggle)
    {
        toglePoprzedniMeat = toggle;
    }
    //public void SelectToggleBuns(Toggle toggle)
   // {
   //     togleActivBuns = toggle;
   // }
  //  public void SelectPoprzedniToggleBuns(Toggle toggle)
   // {
 //       toglePoprzedniBuns = toggle;
   // }

    public void RemoveToggle(Toggle toggle)
    {
        toggleList.Remove(toggle);
    }
}
