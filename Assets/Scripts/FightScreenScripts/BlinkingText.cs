using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{ 
    private TMP_Text _text;
    [SerializeField] private float blinkTime = 2.0f;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b,
                Mathf.Sin(Time.time * 5f) * 0.4f + 0.5f);
            yield return new WaitForSeconds(blinkTime);
        }
    }

    void StartBlinking()
    {
        StartCoroutine("Blink");
    }
    
}

