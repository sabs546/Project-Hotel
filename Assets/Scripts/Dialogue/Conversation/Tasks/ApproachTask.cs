using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTask : BaseTask
{
    public Transform targetTransform;
    public Vector2 movementSpeed;
    public Vector2 minimumSpeed;
    public float movementDecay;
    public float legRoom;

    public void Update()
    {
        ExecuteTask();
        if (objectTransform.position.x <= targetTransform.position.x + legRoom && objectTransform.position.x >= targetTransform.position.x - legRoom &&
            objectTransform.position.y <= targetTransform.position.y + legRoom && objectTransform.position.y >= targetTransform.position.y - legRoom)
        {
            if (nextTask != null)
            {
                nextTask.GetComponent<BaseTask>().enabled = true;
            }
            enabled = false;
        }
    }

    protected override void ExecuteTask()
    {
        // Slow down over time
        if (movementSpeed.x > minimumSpeed.x)
        {
            movementSpeed.x -= movementDecay * Time.deltaTime;
        }
        if (movementSpeed.y > minimumSpeed.y)
        {
            movementSpeed.y -= movementDecay * Time.deltaTime;
        }

        // Moving to the targetted area
        if (objectTransform.position.x >= targetTransform.position.x + legRoom || objectTransform.position.x <= targetTransform.position.x - legRoom)
        {
            if (objectTransform.position.x < targetTransform.position.x)
            {
                objectTransform.Translate(movementSpeed.x * Time.deltaTime, 0.0f, 0.0f);
            }
            else if (objectTransform.position.x > targetTransform.position.x)
            {
                objectTransform.Translate(-movementSpeed.x * Time.deltaTime, 0.0f, 0.0f);
            }
        }

        if (objectTransform.position.y >= targetTransform.position.y + legRoom || objectTransform.position.y <= targetTransform.position.y - legRoom)
        {
            if (objectTransform.position.y < targetTransform.position.y)
            {
                objectTransform.Translate(0.0f, movementSpeed.y * Time.deltaTime, 0.0f);
            }
            else if (objectTransform.position.y > targetTransform.position.y)
            {
                objectTransform.Translate(0.0f, -movementSpeed.y * Time.deltaTime, 0.0f);
            }
        }
    }
}
