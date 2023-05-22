using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleGroupsMy : MonoBehaviour
{

    public ToggleGroup togleGroupInstance;

    public Toggle currentSelection
    {
        get { return togleGroupInstance.ActiveToggles().FirstOrDefault(); }
    }
    // Start is called before the first frame update
    void Start()
    {
        togleGroupInstance = GetComponent<ToggleGroup>();
        Debug.Log("Select" + currentSelection.name);
    }

    public void SelectToggle(int id)
    {
       
        var toggles = togleGroupInstance.GetComponentsInChildren<Toggle>();
      
       // toggles[id].isOn = true;
        Debug.Log("SelectMy" + toggles[id].name);
        Debug.Log("SelectId" + toggles[id].isOn);
    }
}
