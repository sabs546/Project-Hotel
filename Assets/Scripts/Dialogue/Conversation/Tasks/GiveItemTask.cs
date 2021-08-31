using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItemTask : BaseTask
{
    public int givenItemID;

    private void Update()
    {
        ExecuteTask();
    }

    protected override void ExecuteTask()
    {
        actingObject.GetComponent<InventoryMGR>().AddItem(givenItemID);
        if (nextTask != null)
        {
            nextTask.GetComponent<BaseTask>().enabled = true;
        }
        enabled = false;
    }
}
