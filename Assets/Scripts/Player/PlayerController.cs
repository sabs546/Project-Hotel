using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;                // Just movement
    public RectTransform inventory;    // Used for the position of the inventory
    private bool inventoryActive;      // Is the inventory opened
    private Transform transform;       // Just makes getting the transform easier
    private bool trigger;              // Is the inspection text hitbox active
    private bool dTrigger;             // Is the dialogue text hitbox active
    private TextID text;               // Reference to the inspection script
    private DialogueTrigger dText;     // Reference to the dialogue script
    private InventoryMGR inventoryMGR; // Reference to the inventory manager
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        inventoryActive = false;
        trigger = false;
        inventoryMGR = GetComponent<InventoryMGR>();
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
        { // The normal trigger for inspection
            if (Input.GetKeyDown(KeyCode.E))
            {
                text.SetInteraction(!text.active);
                if (text.itemID != -1)
                {
                    inventoryMGR.AddItem(text.itemID);
                    text.itemID = -1;
                }
                if (!text.active)
                    text.ChangeText();
            }
        }

        if (dTrigger && !text.active)
        { // This is the talking trigger, but it only activated when not inspecting
            if (Input.GetKeyDown(KeyCode.R))
            {
                trigger = false;
                dText.TriggerDialogue();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        { // Inventory
            inventoryActive = !inventoryActive;
        }

        if (inventoryActive && inventory.anchoredPosition.y < -63.0f)
        { // Go up when it's not all the way up
            inventory.anchoredPosition = new Vector3(inventory.anchoredPosition.x, inventory.anchoredPosition.y + 1000.0f * Time.deltaTime);
        }
        else if (!inventoryActive && inventory.anchoredPosition.y > -566.0f)
        { // Go down when it's not all the way down
            inventory.anchoredPosition = new Vector3(inventory.anchoredPosition.x, inventory.anchoredPosition.y - 1000.0f * Time.deltaTime);
            if (inventory.anchoredPosition.y < -560.0f)
                inventoryMGR.FullHide();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        trigger = true;
        text = other.gameObject.GetComponent<TextID>();
        if (other.gameObject.GetComponent<DialogueTrigger>() != null)
        { // You can't talk to everything
            dTrigger = true;
            dText = other.gameObject.GetComponent<DialogueTrigger>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    { // Both should stay triggered until you leave
        if (other.gameObject.GetComponent<TextID>() != null)
        {
            trigger = false;
            other.gameObject.GetComponent<TextID>().SetInteraction(false);
        }

        if (other.gameObject.GetComponent<DialogueTrigger>() != null)
        {
            dTrigger = false;
            other.gameObject.GetComponent<DialogueManager>().EndDialogue();
        }
    }
}
