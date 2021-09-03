using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : BaseTask
{
    public string animatorVariable;
    private Animator animator;
    public bool setBool;

    // Start is called before the first frame update
    void Start()
    {
        animator = actingObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteTask();
    }

    protected override void ExecuteTask()
    {
        animator.SetBool(animatorVariable, setBool);
        if (nextTask != null)
        {
            nextTask.GetComponent<BaseTask>().enabled = true;
        }
        enabled = false;
    }
}
