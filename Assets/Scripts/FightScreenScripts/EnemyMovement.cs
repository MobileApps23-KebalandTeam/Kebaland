using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float startingSpeed = 60f;
    private float _currentSpeed;
    [SerializeField] private GameObject target;
    
    [SerializeField] private GameObject player;
    private float _playerNotMovingSpeed;
    private Vector2 _playerStartingPos;

    private void Start()
    {
        _currentSpeed = startingSpeed;
        _playerStartingPos = player.transform.position;
        _playerNotMovingSpeed = player.GetComponent<PlayerMovement>().GetBackgroundSpeed() + startingSpeed;
    }

    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.transform.position;
        int tapCounter = Input.touchCount;
        if (tapCounter == 0 && player.transform.position.y > _playerStartingPos.y)
        {
            _currentSpeed = _playerNotMovingSpeed;
        }
        else 
        {
            _currentSpeed = startingSpeed;
        }
        if (startPosition.y < targetPosition.y)
        {
            transform.position = Vector2.MoveTowards(
                startPosition, targetPosition, _currentSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("wygral");
        }
    }
}
