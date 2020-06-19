using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public RectTransform inventory;
    private bool inventoryActive;
    private Transform transform;
    private bool trigger;
    private bool dTrigger;
    private TextID text;
    private DialogueTrigger dText;
    private InventoryMGR inventoryMGR;
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
        {
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
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                trigger = false;
                dText.TriggerDialogue();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventoryActive = !inventoryActive;
        }

        if (inventoryActive && inventory.anchoredPosition.y < -63.0f)
        {
            inventory.anchoredPosition = new Vector3(inventory.anchoredPosition.x, inventory.anchoredPosition.y + 1000.0f * Time.deltaTime);
        }
        else if (!inventoryActive && inventory.anchoredPosition.y > -566.0f)
        {
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
        {
            dTrigger = true;
            dText = other.gameObject.GetComponent<DialogueTrigger>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
