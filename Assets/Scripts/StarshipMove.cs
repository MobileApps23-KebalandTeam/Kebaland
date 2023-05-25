using UnityEngine;

public class StarshipMove : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;

    private static int _starshipPosition;
    private static int _starshipTargetPosition;
    private static bool _isFirstStart = true;
    private static Vector3 _rotation;
    
    private const float Speed = 60f;
    private readonly Vector3 _shiftVector = new (30, 0, 0);

    void Start()
    {
        if (_starshipPosition % 2 == 0)
        {
            transform.position = planets[_starshipPosition].transform.position + _shiftVector;
            _rotation = new Vector3(1, 1, 0);
        }
        else
        {
            transform.position = planets[_starshipPosition].transform.position - _shiftVector;
            _rotation = new Vector3(-1, 1, 0);
        }
    }
    
    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition;
        
        if (_starshipTargetPosition % 2 == 0)
        {
            targetPosition = planets[_starshipTargetPosition].transform.position + _shiftVector;
        }
        else
        {
            targetPosition = planets[_starshipTargetPosition].transform.position - _shiftVector;
        }
        
        if (startPosition != targetPosition)
        {
            startPosition = transform.position = Vector2.MoveTowards(startPosition, targetPosition, Speed * Time.deltaTime);
            
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
        transform.eulerAngles += new Vector3(0, 0, 45);
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
