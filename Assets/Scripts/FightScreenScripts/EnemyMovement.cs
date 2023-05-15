using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    [SerializeField] private GameObject target;
    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.transform.position;

        if (startPosition != targetPosition)
        {
            transform.position = Vector2.MoveTowards(
                startPosition, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("wygral");
        }
    }
}
