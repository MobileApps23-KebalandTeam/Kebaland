using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject background;
    [SerializeField] private float speed = 90f;
    [SerializeField] private float backgroundSpeed = 400f;
    private Vector2 _startingPoint;

    private void Start()
    {
        _startingPoint = transform.position;
    }

    void Update()
    {
        int tapCounter = Input.touchCount;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = target.transform.position;

        if (tapCounter > 0 && startPosition.y < targetPosition.y)
        {
            background.transform.position += backgroundSpeed * Time.deltaTime * Vector3.down;
            transform.position = Vector2.MoveTowards(
                startPosition, targetPosition, speed * Time.deltaTime);
        } else if (tapCounter == 0) {
            if (startPosition.y > _startingPoint.y)
            {
                transform.position = Vector2.MoveTowards(
                    startPosition, _startingPoint, speed * Time.deltaTime);
                background.transform.position -= (backgroundSpeed) * Time.deltaTime * Vector3.down;
            }
        } else {
            SceneManager.LoadScene("Scenes/LevelPlaceholder");
        }
    }
}
