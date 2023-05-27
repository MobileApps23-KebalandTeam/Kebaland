using UnityEngine;
using UnityEngine.UI;

public class LoadPlanets : MonoBehaviour
{
    [SerializeField] private GameObject startingPlanet;
    [SerializeField] private GameObject endingPlanet;
    void Start()
    {
        int planetToPass = LevelChoice.GetStartedLevel();
        Sprite planet2 = Resources.Load <Sprite>("Planets/planet-" + (planetToPass));
        if (planetToPass == 0)
        {
            planetToPass = 1;
        }
        Sprite planet1 = Resources.Load<Sprite>("Planets/planet-" + (planetToPass - 1));
        startingPlanet.gameObject.GetComponent<Image>().sprite = planet1;
        endingPlanet.GetComponent<Image>().sprite = planet2;
    }
}
