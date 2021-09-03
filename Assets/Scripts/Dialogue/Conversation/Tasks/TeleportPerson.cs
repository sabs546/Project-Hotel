using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPerson : BaseTask
{
    public Transform teleportArea;

    // Update is called once per frame
    void Update()
    {
        ExecuteTask();
    }

    protected override void ExecuteTask()
    {
        actingObject.transform.position = teleportArea.position;
        if (nextTask != null)
        {
            nextTask.GetComponent<BaseTask>().enabled = true;
        }
        enabled = false;
    }
}
