using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessageUtils : MonoBehaviour
{
    TMPro.TextMeshProUGUI txt;
    Image image;

    private void Start()
    {
        txt = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        image = GetComponent<Image>();
        txt.enabled = false;
        image.enabled = false;
    }

    public void ShowToast(string text, float duration)
    {
        StartCoroutine(ShowToastCOR(text, duration));
    }

    private IEnumerator ShowToastCOR(string text, float duration)
    {

        txt.text = text;
        txt.enabled = true;
        image.enabled = true;

        //Fade in
        yield return FadeInAndOut(true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return FadeInAndOut(false, 0.5f);

        txt.enabled = false;
        image.enabled = false;
    }

    private IEnumerator FadeInAndOut(bool fadeIn, float duration)
    {
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        float counter = 0f;

        Color orginalColor = txt.color;
        Color imageColor = image.color;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            txt.color = new Color(orginalColor.r, orginalColor.g, orginalColor.b, alpha);
            image.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return null;
        }
    }
}
