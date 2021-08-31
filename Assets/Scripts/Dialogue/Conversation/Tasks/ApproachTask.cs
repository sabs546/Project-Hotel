using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTask : BaseTask
{
    public Transform targetTransform;
    public Vector2 movementSpeed;

    public void Update()
    {
        ExecuteTask();
        if (objectTransform.position.x <= targetTransform.position.x + 3.0f && objectTransform.position.x >= targetTransform.position.x - 3.0f &&
            objectTransform.position.y <= targetTransform.position.y + 3.0f && objectTransform.position.y >= targetTransform.position.y - 3.0f)
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
        // Moving to the targetted area
        if (objectTransform.position.x >= targetTransform.position.x + 3.0f || objectTransform.position.x <= targetTransform.position.x - 3.0f)
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

        if (objectTransform.position.y >= targetTransform.position.y + 3.0f || objectTransform.position.y <= targetTransform.position.y - 3.0f)
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
