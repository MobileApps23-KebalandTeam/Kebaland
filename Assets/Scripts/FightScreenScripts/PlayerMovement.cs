using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 90f;

    void Update()
    {
        int tapCounter = Input.touchCount;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.transform.position;
        if (tapCounter > 0 && startPosition != targetPosition)
        {
            transform.position = Vector2.MoveTowards(
                startPosition, targetPosition, speed * Time.deltaTime);
        }

        if (transform.position == target.transform.position)
        {
            SceneManager.LoadScene("Scenes/LevelPlaceholder");
        }
    }
}
