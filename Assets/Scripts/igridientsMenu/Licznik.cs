using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Licznik : MonoBehaviour
{
    public Text textComponent;
    public ToggleManeger toggleManager;
    public int licznikPoprzedni;
    public int maxLiczba = 12;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        licznikPoprzedni = 4;
    }

    // Update is called once per frame
    public void Zmien(bool wybur)
    {
        if (toggleManager != null)
        {
            Debug.Log(toggleManager.toggleList.Count);
            if (wybur)
            {
               // if (licznikPoprzedni != toggleManager.toggleList.Count)
               // {
                    licznikPoprzedni = licznikPoprzedni - 1;
                //textComponent.text = $"{licznikPoprzedni - toggleManager.toggleList.Count}";
             //   Debug.Log("AAAA " + (licznikPoprzedni - toggleManager.toggleList.Count));
                textComponent.text = $"{licznikPoprzedni}";
               Debug.Log("AAAA " + licznikPoprzedni);
                Debug.Log("YES");
               // }

            }
            else {
                Debug.Log("NO");
               // if (licznikPoprzedni != toggleManager.toggleList.Count)
              //  {
                    licznikPoprzedni = licznikPoprzedni + 1;
               Debug.Log("BBB " + licznikPoprzedni);
               // Debug.Log("BBB " + (licznikPoprzedni - toggleManager.toggleList.Count));
               // textComponent.text = $"{licznikPoprzedni - toggleManager.toggleList.Count}";
               textComponent.text = $"{licznikPoprzedni}";
               // }

            }
            
        }
    }
}

