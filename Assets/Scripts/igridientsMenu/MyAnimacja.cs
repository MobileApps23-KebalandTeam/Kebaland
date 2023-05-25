using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAnimacja : MonoBehaviour
{
    public Image image;
    public MyButton button;
    public float moveDuration = 2.0f; // Zwiększając tę wartość, animacja będzie wolniejsza
    public Vector2 startPosition;
    public Vector2 endPosition;

    private bool isMoving = false;
    private float moveTimer = 0.0f;


    private void Update()
    {
        if (isMoving)
        {
            moveTimer += Time.deltaTime;

            float t = Mathf.Clamp01(moveTimer / moveDuration);
            image.rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);

            if (t >= 1.0f)
            {
                isMoving = false;
                moveTimer = 0.0f;
                StartCoroutine(button.DisableToggleInteraction()); // Uruchamiamy po zakończeniu przesuwania obrazka
            }
        }
    }

    public void StartImageMove()
    {
        if (button.animacja)
        {
            isMoving = true;
            image.rectTransform.anchoredPosition = startPosition;
        }
    }
}