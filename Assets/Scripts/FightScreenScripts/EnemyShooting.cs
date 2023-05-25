using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    private float _timer;
    private int _spawnTime;
    void Start()
    {
        _spawnTime = 4 - (LevelChoice.GetStartedLevel() / 3);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnTime)
        {
            _timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 startPosition = bulletPosition.position;
        EnemyMovement enemyMovement = gameObject.GetComponent<EnemyMovement>();
        startPosition -= Time.deltaTime * (enemyMovement.GetCurrentSpeed()) * (Vector2) transform.right ;
        GameObject b = Instantiate(bullet, startPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }
}
