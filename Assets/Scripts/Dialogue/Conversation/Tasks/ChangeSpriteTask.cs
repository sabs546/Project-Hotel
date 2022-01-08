using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteTask : BaseTask
{
    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteTask();
    }

    protected override void ExecuteTask()
    {
        actingObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        if (nextTask != null)
        {
            nextTask.GetComponent<BaseTask>().enabled = true;
        }
        enabled = false;
    }
}
