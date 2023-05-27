using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsOrders
{

    public static void AddOrders(int lvl)
    {
        if (lvl == 0)
        {
            OrderList.AddDelayedKebabRequest(0.5f, 50.0f);
            OrderList.AddDelayedKebabRequest(15.0f, 50.0f);
            OrderList.AddDelayedKebabRequest(50.0f, 40.0f);
            OrderList.AddDelayedKebabRequest(80.0f, 60.0f);
            OrderList.AddDelayedKebabRequest(100.0f, 50.0f);
        }
    }

}
