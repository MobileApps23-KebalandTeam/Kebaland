using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MeatScript;

public class Background : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 target;
    private float multSpeed = 1.0f;
    private Dictionary<FinalMeat, Vector3> meatTargets = new Dictionary<FinalMeat, Vector3>();

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime * 100 * multSpeed);

        foreach (KeyValuePair<FinalMeat, Vector3> pair in meatTargets)
        {
            pair.Key.obj.transform.position = Vector3.MoveTowards(pair.Key.obj.transform.position, pair.Value, moveSpeed * Time.deltaTime * 100 * multSpeed);
        }
    }


    public void MoveFast(Vector3 toDirection)
    {
        multSpeed = 3.0f;
        AddDirection(toDirection);
    }

    public void Move(Vector3 toDirection)
    {
        multSpeed = 1.0f;
        AddDirection(toDirection);
    }

    public void AddMeat(FinalMeat meat)
    {
        meatTargets.Add(meat, meat.obj.transform.position);
    }

    public void RemoveMeat(FinalMeat meat)
    {
        meatTargets.Remove(meat);
    }

    private void AddDirection(Vector3 toDirection)
    {
        target += toDirection;
        List<FinalMeat> keys = new List<FinalMeat>(meatTargets.Keys);
        foreach (FinalMeat key in keys)
        {
            meatTargets[key] += toDirection;
        }
    }

}
