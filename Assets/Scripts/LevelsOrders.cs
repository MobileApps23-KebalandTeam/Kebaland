using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsOrders
{

    public static void AddOrders(int lvl)
    {
        if (lvl == 0)
        {
            for (int _ = 0; _ < 15; _++)
                OrderList.AddKebabRequest(OrderType.Kebab1, 100.0f);
            OrderList.AddKebabRequest(OrderType.Kebab2, 50.0f);
            OrderList.AddKebabRequest(OrderType.Kebab3, 20.0f);
            OrderList.AddKebabRequest(OrderType.Kebab3, 5.0f);
        }
    }

}
