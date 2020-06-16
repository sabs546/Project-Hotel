using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Transform transform;
    private bool trigger;
    private TextID text;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        trigger = false;
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

    private void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                text.SetInteraction(!text.active);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        trigger = true;
        text = other.gameObject.GetComponent<TextID>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TextID>() != null)
        {
            trigger = false;
            other.gameObject.GetComponent<TextID>().SetInteraction(false);
        }
    }
}
