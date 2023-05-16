using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 target;
    private float multSpeed = 1.0f;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime * 100 * multSpeed);
    }


    public void MoveFast(Vector3 toDirection)
    {
        multSpeed = 3.0f;
        target += toDirection;
    }

    public void Move(Vector3 toDirection)
    {
        multSpeed = 1.0f;
        target += toDirection;
    }

}
