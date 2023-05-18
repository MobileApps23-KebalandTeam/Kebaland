using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{ 
    private TMP_Text text;
    [SerializeField] private float blinkTime = 2.0f;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (text.color.a)
            {
                case 0.3f:
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
                    yield return new WaitForSeconds(blinkTime);
                    break;
                case 0.6f:
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.3f);
                    yield return new WaitForSeconds(blinkTime);
                    break;
                case 1.0f:
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.6f);
                    yield return new WaitForSeconds(blinkTime);
                    break;
            }
        }
    }

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
    
}

