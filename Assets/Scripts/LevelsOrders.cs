using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsOrders
{

    public static void AddOrders(int lvl)
    {
        if (lvl == 0)
        {
            OrderList.AddKebabRequest(OrderType.Kebab1, 20.0f);
            OrderList.AddKebabRequest(OrderType.Kebab1, 50.0f);
            OrderList.AddKebabRequest(OrderType.Kebab1, 100.0f);
            OrderList.AddDelayedKebabRequest(5.0f, OrderType.Kebab1, 50.0f);
        }
    }

}
