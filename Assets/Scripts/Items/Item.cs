using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public int ID;
    public string name;
    public string description;
    public virtual void GenerateItem(ref Item item) {}
}
