using System;
using Core;
using Model;
using TMPro;
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
    [SerializeField] private GameObject endGameInfo;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    private float _playerNotMovingSpeed;
    private Vector2 _playerStartingPos;
    private bool _isEnd = false;
    private float _timeAfterReachingEnd = 0;

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
        if (!_isEnd)
        {
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
                startPosition += Time.deltaTime * _currentSpeed * (Vector2)transform.up;
                transform.position = startPosition + magnitude * Mathf.Sin(Time.time * frequency) * (Vector2)transform.right;
            }
            else
            {
                _isEnd = true;
                tutorialText.SetActive(false);
                endGameInfo.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                enemy.GetComponent<EnemyShooting>().enabled = false;
                BulletMoving[] bullets = FindObjectsOfType<BulletMoving>();
                foreach (var bullet in bullets)
                {
                    bullet.StopBullet();
                    bullet.enabled = false;
                }
            }
        }
        else if (_timeAfterReachingEnd > 2)
        {
            if (tapCounter > 0)
            {
                //set achievement
                AchievementManager.Instance.setDelayedEarnAchievement("Quacamole na pokładzie");
                clickerFailed();
            }
        }
        else
        {
            _timeAfterReachingEnd += Time.deltaTime;
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

    public void SetIsEnd(bool end)
    {
        _isEnd = end;
    }

    private void clickerFailed()
    {
        LevelChoice.UpdateLevel(false, LevelType.CLICKER);
        SceneManager.LoadScene("LevelsChoiceScene");
    }
}
