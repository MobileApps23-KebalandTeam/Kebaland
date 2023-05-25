using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject background;
    [SerializeField] private float speed = 110f;
    [SerializeField] private float backgroundSpeed = 400f;
    private Vector2 _startingPoint;
    private float _currentSpeed = 0f;

    private void Start()
    {
        _startingPoint = transform.position;
    }

    void Update()
    {
        int tapCounter = Input.touchCount;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.transform.position;

        // Player moves taps the screen - moves towards the target
        if (tapCounter > 0 && startPosition.y < targetPosition.y)
        {
            _currentSpeed = speed;
            Move(startPosition, targetPosition, false);
        } 
        // Player stops tapping - begins falling
        else if (tapCounter == 0) 
        {
            if (startPosition.y > _startingPoint.y)
            {
                Move(startPosition, _startingPoint, true);
            }
        } 
        else
        {
            //Uncomment to add logbook entry
            
            /*MLogbookEntry entry = new();
            entry.LevelNumber = ???;
            entry.passedTime = DateTime.Now.Ticks;
            ServiceLocator.Get<LogbookService>().AddEntry(entry);*/
            
            SceneManager.LoadScene("Scenes/LevelPlaceholder");
        }
    }

    private void Move(Vector2 startPosition, Vector2 targetPosition, bool isFalling)
    {
        if (!isFalling)
        {
            background.transform.position += backgroundSpeed * Time.deltaTime * Vector3.down;
            transform.position = Vector2.MoveTowards(
                startPosition, targetPosition, _currentSpeed * Time.deltaTime);
        }
        else
        {
            background.transform.position -= (backgroundSpeed) * Time.deltaTime * Vector3.down;
            transform.position = Vector2.MoveTowards(
                startPosition, targetPosition, _currentSpeed * Time.deltaTime);
        }
    }

    public float GetBackgroundSpeed()
    {
        return backgroundSpeed;
    }

    public float GetPlayerSpeed()
    {
        return _currentSpeed;
    }
}
