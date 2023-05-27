using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatScript : MonoBehaviour
{
    class SimpleMeat
    {
        public Vector2 target;
        public Vector2 from;
        public GameObject obj;

        private float i = 0f;

        private float states = 2f;

        public SimpleMeat(Vector2 from, Vector2 target, GameObject obj)
        {
            this.from = from;
            this.target = target;
            this.obj = obj;
        }

        public Vector2 GetActualTarget()
        {
            i += Time.deltaTime;
            return from + (target - from) * i / states + 300 * new Vector2(0,
                i * (states - i) * (i - states * 95 / 100) * (i - states * 95 / 100));
        }

        public bool IsEnd()
        {
            return i >= states;
        }
    }

    public class FinalMeat
    {
        public Vector2 from;
        public GameObject obj;

        public FinalMeat(Vector2 from, GameObject obj)
        {
            this.from = from;
            this.obj = obj;
        }
    }

    public Background background;
    public GameObject meatObject;
    public GameObject boxObject;
    public GameObject parentForMeat;
    public float moveSpeed = 5.0f;
    private List<SimpleMeat> meatList = new List<SimpleMeat>();
    private List<FinalMeat> cutList = new List<FinalMeat>();

    private void Update()
    {
        for (int i = meatList.Count - 1; i >= 0; i--)
        {
            SimpleMeat meat = meatList[i];
            meat.obj.transform.position =
                Vector3.MoveTowards(meat.obj.transform.position, meat.GetActualTarget(), moveSpeed * 1000);
            if (meat.IsEnd())
            {
                meatList.RemoveAt(i);
                AddFinalMeat(new FinalMeat(meat.target, meat.obj));
                meat.obj.GetComponent<BoxCollider>().size = new Vector2(Screen.width / 24, Screen.height / 24);
                meat.obj.transform.SetParent(parentForMeat.transform);
            }
        }
    }

    public void CutMeat(Vector2 fromPos)
    {
        Vector2 from = fromPos + new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        float xDiff = Screen.width / 7, yDiff = Screen.height / 28;
        Vector2 target = (Vector2)boxObject.transform.position +
                         new Vector2(Random.Range(-xDiff, xDiff), Random.Range(-yDiff, yDiff));
        var newObj = Instantiate(meatObject, from, Quaternion.identity, transform);
        meatList.Add(new SimpleMeat(from, target, newObj));
    }

    public List<FinalMeat> CutList()
    {
        return cutList;
    }

    public void AddFinalMeat(FinalMeat meat)
    {
        cutList.Add(meat);
        background.AddMeat(meat);
    }

    public void RemoveFinalMeat(FinalMeat meat)
    {
        cutList.Remove(meat);
        background.RemoveMeat(meat);
    }

    public void RemoveRest()
    {
        foreach (SimpleMeat meat in meatList)
        {
            Destroy(meat.obj);
        }

        meatList.Clear();
    }

    public List<FinalMeat> GetFinalMeatList()
    {
        return cutList;
    }

    public void play()
    {
        if (MusicScript.isMusicEnabled) GetComponent<AudioSource>().Play();
    }

    public void stop()
    {
        GetComponent<AudioSource>().Stop();
    }
}