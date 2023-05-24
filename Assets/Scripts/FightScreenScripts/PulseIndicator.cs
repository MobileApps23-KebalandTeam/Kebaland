using System;
using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PulseIndicator : MonoBehaviour
{
    private Image _image;
    [SerializeField] private bool isGreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float blinkTime = 0.5f;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0f);
    }

    private void Update()
    {
        if (isGreen && player.transform.position.y - enemy.transform.position.y > 8 * Screen.height/10f)
        {
            StartBlinking();
        }
        else if (isGreen)
        {
            StopBlinking();
        } 
        else if (enemy.transform.position.y - player.transform.position.y > 8 * Screen.height / 10f)
        {
            StartBlinking();
        }
        else
        {
            StopBlinking();
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b,
                Mathf.Sin(Time.time * 7f) * 0.5f + 0.5f);
            yield return new WaitForSeconds(blinkTime);
        }
    }

    private void StartBlinking()
    {
        StartCoroutine("Blink");
    }

    private void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
