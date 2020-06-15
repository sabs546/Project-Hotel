using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        { // Up
            transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        { // Down
            transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        { // Left
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        { // Right
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    private void Collider()
    {

    }
}
