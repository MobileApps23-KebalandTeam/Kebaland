using System;
using Core;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float startingSpeed = 60f;
    [SerializeField] private float frequency = 3f;
    [SerializeField] private float magnitude = 0.2f;
    [SerializeField] private float speedModifier = 20f;
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
            if (tapCounter > 2)
            {
                _currentSpeed = startingSpeed - speedModifier;
            }
            else
            {
                _currentSpeed = startingSpeed;
            }
            
        }
        if (startPosition.y < targetPosition.y)
        {
            startPosition += Time.deltaTime * _currentSpeed * (Vector2) transform.up ;
            transform.position = startPosition + magnitude * Mathf.Sin(Time.time * frequency) * (Vector2)transform.right;
        }
        else
        {
            //Uncomment to add logbook entry
            
            /*MLogbookEntry entry = new();
            entry.LevelNumber = ???;
            entry.passedTime = DateTime.Now.Ticks;
            ServiceLocator.Get<LogbookService>().AddEntry(entry);*/
            
            LevelChoice.UpdateLevel(false);
            SceneManager.LoadScene("LevelsChoiceScene");
        }
    }

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }
    public float GetMagnitude()
    {
        return magnitude;
    }

    public float GetFrequency()
    {
        return frequency;
    }
}
