using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnterDoorTask : BaseTask
{
    public Vector2 speed;
    public Vector2 distance;

    private Vector2 recordedDistance;
    private BoxCollider2D doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponentsInParent<BoxCollider2D>().First(n => !n.isTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteTask();
    }

    protected override void ExecuteTask()
    {
        if (recordedDistance.x < distance.x || recordedDistance.y < distance.y)
        {
            if (Mathf.Abs(speed.x) > 0.0f)
            {
                doorCollider.enabled = false;
                actingObject.transform.position += new Vector3(speed.x * Time.deltaTime, 0.0f, 0.0f);
                recordedDistance.x += Mathf.Abs(speed.x) * Time.deltaTime;
            }
            if (Mathf.Abs(speed.y) > 0.0f)
            {
                doorCollider.enabled = false;
                actingObject.transform.position += new Vector3(0.0f, speed.y * Time.deltaTime, 0.0f);
                recordedDistance.y += Mathf.Abs(speed.y) * Time.deltaTime;
            }
        }
        else
        {
            if (nextTask != null)
            {
                nextTask.GetComponent<BaseTask>().enabled = true;
            }
            enabled = false;
        }
    }
}
