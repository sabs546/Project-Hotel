using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeItem : Item
{
    public override void GenerateItem(ref Item item)
    {
        item.ID = 2;
        item.name = "Orange";
        item.description = "It's a pretty good orange, you bought it from some weirdo";
    }
}
