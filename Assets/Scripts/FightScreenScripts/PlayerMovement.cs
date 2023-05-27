using System.Collections;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject endGameInfo;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed = 110f;
    [SerializeField] private float backgroundSpeed = 400f;
    private Vector2 _startingPoint;
    private float _currentSpeed = 0f;
    private bool _isEnd = false;
    private float _timeAfterReachingEnd = 0;

    private void Start()
    {
        _startingPoint = transform.position;
    }

    void Update()
    {
        int tapCounter = Input.touchCount;
        if (!_isEnd)
        {
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
            
                tutorialText.SetActive(false);
                endGameInfo.GetComponentInChildren<TMP_Text>().text =
                    "To mały krok dla człowieka, \n ale wielki krok dla Imperium Kebaba!";
                endGameInfo.SetActive(true);
                _currentSpeed = 0;
                backgroundSpeed = 0;
                enemy.gameObject.GetComponent<EnemyMovement>().enabled = false;
                enemy.gameObject.GetComponent<EnemyShooting>().enabled = false;
                BulletMoving[] bullets = FindObjectsOfType<BulletMoving>();
                foreach (var bullet in bullets)
                {
                    bullet.StopBullet();
                    bullet.enabled = false;
                }
                _isEnd = true;
            } 
        }
        else if (_timeAfterReachingEnd > 2)
        {
            if (tapCounter > 0)
            {
                clickerPassed();
            }
            
        }
        else
        {
            _timeAfterReachingEnd += Time.deltaTime;
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

    private void clickerPassed()
    {
        //TODO FIX USAGE
        // AchievementManager.Instance.setDelayedEarnAchievement("Space Wars");
        LevelsOrders.AddOrders(0);
        LevelChoice.UpdateLevel(true, LevelType.CLICKER);
        IngredientsHolder.SetType(0, IngredientType.Pepper);
        IngredientsHolder.SetType(1, IngredientType.Tomato);
        SceneManager.LoadScene("GameLoopScene");
    }
}
