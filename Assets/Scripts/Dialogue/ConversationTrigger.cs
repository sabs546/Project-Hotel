using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationTrigger : MonoBehaviour
{
    public SpriteRenderer portrait;      // The portrait area of the guy
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;    // The entire dialogue area
    public Conversation conversation;

    private Queue<Sprite> linkedPortrait;
    private Queue<string> linkedName;
    private Queue<string> sentences;     // All of the text for multiple lines of text

    // Start is called before the first frame update
    void Start()
    {
        linkedPortrait = new Queue<Sprite>();
        linkedName = new Queue<string>();
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue()
    {
        dialogueObject.SetActive(true);
        foreach (ConversationDialogue dialogue in conversation.dialogue)
        {
            foreach (string sentence in dialogue.sentences)
            {
                linkedPortrait.Enqueue(dialogue.portrait);
                linkedName.Enqueue(dialogue.name);
                sentences.Enqueue(sentence);
            }
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        { // If the sentences run out put it away
            EndDialogue();
            return;
        }

        portrait.sprite = linkedPortrait.Dequeue();
        nameText.text = linkedName.Dequeue();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    { // Display letters one by one
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueObject.SetActive(true);
        StartDialogue();
        DisplayNextSentence();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
    }
}