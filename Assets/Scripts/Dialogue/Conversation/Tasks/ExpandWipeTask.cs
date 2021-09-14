using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandWipeTask : BaseTask
{
    private RectTransform wipeRect;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        wipeRect = actingObject.GetComponent<RectTransform>();
        spr = wipeRect.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wipeRect.localScale.y < 1750.0f)
        {
            wipeRect.localScale = new Vector3(wipeRect.localScale.x, wipeRect.localScale.y + 10.0f, wipeRect.localScale.x);
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
