using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    [SerializeField] private GameObject target;
    
    [SerializeField] private GameObject player;
    private Vector2 _playerStartingPos;

    private void Start()
    {
        _playerStartingPos = player.transform.position;
    }

    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.transform.position;
        int tapCounter = Input.touchCount;
        if (tapCounter == 0 && player.transform.position.y > _playerStartingPos.y)
        {
            speed = 460f;
        }
        else 
        {
            speed = 60f;
        }
        if (startPosition.y < targetPosition.y)
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
