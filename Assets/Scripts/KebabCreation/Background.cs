using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime * 100);
    }

    public void Move(Vector3 toDirection)
    {
        target += toDirection;
    }

}
