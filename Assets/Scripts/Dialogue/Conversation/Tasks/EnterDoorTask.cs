using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnterDoorTask : BaseTask
{
    public Vector2 speed;
    public Vector2 distance;
    
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
        if (Mathf.Abs(speed.x) > 0.0f || Mathf.Abs(speed.y) > 0.0f)
        {
            doorCollider.enabled = false;
            actingObject.transform.position += new Vector3(speed.x * Time.deltaTime, speed.y * Time.deltaTime, 0.0f);
        }
    }
}
