using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    private float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2)
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
        //b.transform.SetParent(GameObject.FindGameObjectWithTag("Enemy").transform, false);
    }
}
