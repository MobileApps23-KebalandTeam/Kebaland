using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePulsing : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float blinkTime = 0.5f;
    private bool isActive = true;

    private void Start()
    {
        _transform = gameObject.transform;
    }

    private void Update()
    {
        if (isActive)
        {
            StartBlinking();
        }
        else
        {
            StopBlinking();
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            float size = Mathf.Sin(Time.time * 3f) * 0.07f + 0.93f;
            _transform.localScale = new Vector3(size, size, gameObject.transform.localScale.z);
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

    public void SetActive(bool active)
    {
        isActive = active;
    }
}
