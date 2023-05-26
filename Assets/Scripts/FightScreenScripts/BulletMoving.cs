using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float force;
    [SerializeField] private float accuracyModifier = 800f;
    private float _timer = 0;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        float levelNumber = LevelChoice.GetStartedLevel();
        accuracyModifier -= (3 - levelNumber/3) * 100;
        Vector3 direction = _player.transform.position + new Vector3(0,_player.GetComponent<PlayerMovement>().GetPlayerSpeed() * accuracyModifier * Time.deltaTime , 0) - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.GetComponent<PlayerLife>().SubtractLife();
            Destroy(gameObject);
        }
    }
}
