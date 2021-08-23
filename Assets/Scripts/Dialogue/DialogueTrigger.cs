using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;
    private InventoryMGR inventoryMGR;

    private void Start()
    {
        inventoryMGR = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryMGR>();
    }

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue); // Start talking
        manager.DisplayNextSentence(); // Otherwise it's just empty at first
    }
}
