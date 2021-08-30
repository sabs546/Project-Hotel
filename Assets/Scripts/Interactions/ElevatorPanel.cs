using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{

    private BoxCollider2D doorCollider;    // This will need removing so you can walk to the new room
    private BoxCollider2D doorInteraction; // It might clash, just in case
    private Animator      animator;        // Door open animation
    private bool          trigger;         // In trigger range
    private GameObject    interaction;     // So closing the interaction box doesn't close the door
    public  bool          close;           // Close the door instead

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D[] tempCollider = GetComponentsInParent<BoxCollider2D>();
        foreach (BoxCollider2D collider in tempCollider.Where(n => n.name != name))
        {
            if (collider.isTrigger)
            {
                doorInteraction = collider;
            }
            else
            {
                doorCollider = collider;
            }
        }
        animator = GetComponentInParent<Animator>();
        interaction = GetComponent<TextID>().interaction;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger && Input.GetKeyDown(KeyCode.E) && interaction.activeSelf)
        { // Elevator door open code
            animator.SetBool("Open", !close);
            doorCollider.enabled = close;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Load up a new room here
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        trigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
    }
}
