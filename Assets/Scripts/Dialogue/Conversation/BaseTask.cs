using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTask : MonoBehaviour
{
    public GameObject actingObject;
    public GameObject nextTask;
    protected Transform objectTransform;

    private void Start()
    {
        objectTransform = actingObject.transform;
    }

    protected virtual void ExecuteTask() {}
}
