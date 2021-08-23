using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 1;
        item.name = "Cash";
        item.description = "Can probably buy something with it";
    }
}
