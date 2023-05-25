using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float force;
    [SerializeField] private float accuracyModifier = 800f;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = _player.transform.position + new Vector3(0,_player.GetComponent<PlayerMovement>().GetPlayerSpeed() * accuracyModifier * Time.deltaTime , 0) - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
