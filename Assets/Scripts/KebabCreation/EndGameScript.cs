using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{

    private float duration = 2.0f;
    private float toAlpha = 0.7f;
    private Image image;

    private GameObject titleText;



    public void Show(int sumPoints, int reqPoints, int sumOrders)
    {
        gameObject.SetActive(true);

        bool won = sumPoints >= reqPoints;


        LevelChoice.UpdateLevel(won, LevelType.KEBAB);

        image = GetComponent<Image>();
        image.enabled = true;

        Dictionary<GameObject, float> list = new Dictionary<GameObject, float>();
        List<Transform> toAdd = new List<Transform>();
        List<Transform> toGo = new List<Transform>();
        foreach (Transform trans in transform) toAdd.Add(trans);

        int ind = 0;
        while (toAdd.Count > 0)
        {
            ind++;
            foreach (Transform add in toAdd)
            {
                toGo.Add(add);
            }
            toAdd.Clear();

            foreach (Transform trans in toGo)
            {
                foreach (Transform child in trans)
                {
                    toAdd.Add(child);
                }
                if (trans.name.Equals("TitleText"))
                    trans.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = won ? "Gratulacje!" : "Spróbuj ponownie";
                else if (trans.name.Equals("PointsText"))
                    trans.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = sumPoints + "";
                else if (trans.name.Equals("OrdersText"))
                    trans.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = sumOrders + "";
                list.Add(trans.gameObject, 0);
            }
            toGo.Clear();
        }

        Dictionary<GameObject, float> list2 = new Dictionary<GameObject, float>();

        foreach (KeyValuePair<GameObject, float> child in list)
        {
            bool isImage = child.Key.GetComponent<Image>() != null;
            Color childColor = isImage ? child.Key.GetComponent<Image>().color : child.Key.GetComponent<TMPro.TextMeshProUGUI>().color;
            list2.Add(child.Key, childColor.a);
            if (isImage)
                child.Key.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, 0f);
            else
                child.Key.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(childColor.r, childColor.g, childColor.b, 0f);
        }

        StartCoroutine(ShowPanel(list2));
    }

    private IEnumerator ShowPanel(Dictionary<GameObject, float> list)
    {
        float a = 0f, b = toAlpha;

        Color backgroundColor = image.color;
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            image.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
            
            foreach (KeyValuePair<GameObject, float> child in list)
            {
                bool isImage = child.Key.GetComponent<Image>() != null;
                Color childColor = isImage ? child.Key.GetComponent<Image>().color : child.Key.GetComponent<TMPro.TextMeshProUGUI>().color;
                float alpha2 = Mathf.Lerp(0f, child.Value, counter / duration);
                if (isImage)
                    child.Key.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, alpha2);
                else
                    child.Key.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(childColor.r, childColor.g, childColor.b, alpha2);
            }

            yield return null;
        }
        if (counter > duration)
            GetComponentInChildren<Image>().enabled = true;
    }

    public void GoToMap()
    {
        SceneManager.LoadScene("LevelsChoiceScene");
        TotalCleaner.ClearAll();
    }

}
