using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollider : MonoBehaviour
{
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Collider(Transform obj)
    {
        if (obj.position.y >= tf.position.y - (tf.position.y + obj.position.y)   &&
            obj.position.y <= tf.position.y + (tf.position.y + obj.localScale.y) &&
            obj.position.x >= tf.position.x - (tf.position.x + obj.position.y)   &&
            obj.position.x <= tf.position.x + (tf.position.x + obj.localScale.y))
        {
            return true;
        }
        return false;
    }
}
