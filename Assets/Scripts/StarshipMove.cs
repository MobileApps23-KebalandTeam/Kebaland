using System;
using Unity.VisualScripting;
using UnityEngine;

public class StarshipMove : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;

    private static int _starshipPosition;
    private static int _starshipTargetPosition;
    private static bool _isFirstStart = true;
    private static Vector3 _rotation;
    private float _planetHorizontalShift;
    private float _speed;
    
    private const int VerticalMovePadding = 50;
    private const int AssetRotation = 45;

    void Start()
    {
        _planetHorizontalShift = Screen.width / 10f;
        _speed = Screen.height / 10f;
        
        Vector2 startPosition = planets[_starshipPosition].transform.position;

        if (_starshipPosition % 2 == 0)
        {
            startPosition.x += _planetHorizontalShift;
            transform.position = 
            _rotation = new Vector3(1, 1, 0);
        }
        else
        {
            startPosition.x -= _planetHorizontalShift;
            _rotation = new Vector3(-1, 1, 0);
        }
        
        startPosition.y = Math.Max(startPosition.y, -VerticalMovePadding);
        startPosition.y = Math.Min(startPosition.y, Screen.height + VerticalMovePadding);
        transform.position = startPosition;
    }
    
    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = planets[_starshipTargetPosition].transform.position;
        
        if (_starshipTargetPosition % 2 == 0)
        {
            targetPosition.x += _planetHorizontalShift;
        }
        else
        {
            targetPosition.x += _planetHorizontalShift;
        }

        targetPosition.y = Math.Max(targetPosition.y, -VerticalMovePadding);
        targetPosition.y = Math.Min(targetPosition.y, Screen.height + VerticalMovePadding);

        if (startPosition != targetPosition)
        {
            startPosition = transform.position = Vector2.MoveTowards(startPosition, targetPosition, _speed * Time.deltaTime);
            
            if ((Vector3) (targetPosition - startPosition) != new Vector3(0, 0, 0))
            {
                _rotation = targetPosition - startPosition;
            }
        }
        else
        {
            _starshipPosition = _starshipTargetPosition;
        }

        transform.up = _rotation;
        transform.eulerAngles += new Vector3(0, 0, AssetRotation);
    }

    private void OnDestroy()
    {
        _starshipPosition = _starshipTargetPosition;
    }

    public static void SetTargetPosition(int newPosition)
    {
        _starshipTargetPosition = newPosition;
    }
    
    public static void SetPositionForce(int newPosition)
    {
        if (_isFirstStart)
        {
            _starshipTargetPosition = newPosition;
            _starshipPosition = newPosition;
            _isFirstStart = false;
        }
    }
}
