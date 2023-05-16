using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{

    private float duration = 2.0f;
    private float toAlpha = 0.7f;
    private Image image;



    public void Show()
    {
        gameObject.SetActive(true);

        image = GetComponent<Image>();
        image.enabled = true;

        List<GameObject> list = new List<GameObject>();
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
                list.Add(trans.gameObject);
            }
            toGo.Clear();
        }

        foreach (GameObject child in list)
        {
            bool isImage = child.GetComponent<Image>() != null;
            Color childColor = isImage ? child.GetComponent<Image>().color : child.GetComponent<TMPro.TextMeshProUGUI>().color;
            if (isImage)
                child.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, 0f);
            else
                child.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(childColor.r, childColor.g, childColor.b, 0f);
        }

        StartCoroutine(ShowPanel(list));
    }

    private IEnumerator ShowPanel(List<GameObject> list)
    {
        float a = 0f, b = toAlpha;

        float a2 = 0f, b2 = 1f;

        Color backgroundColor = image.color;
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            image.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
            
            foreach (GameObject child in list)
            {
                bool isImage = child.GetComponent<Image>() != null;
                Color childColor = isImage ? child.GetComponent<Image>().color : child.GetComponent<TMPro.TextMeshProUGUI>().color;
                float alpha2 = Mathf.Lerp(a2, b2, counter / duration);
                if (isImage)
                    child.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, alpha2);
                else
                    child.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(childColor.r, childColor.g, childColor.b, alpha2);
            }

            yield return null;
        }
        if (counter > duration)
            GetComponentInChildren<Image>().enabled = true;
    }

}
