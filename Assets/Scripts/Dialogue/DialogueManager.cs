using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image portrait;               // The portrait area of the guy (yet to be implemented)
    public TextMeshProUGUI nameText;     // The name area
    public TextMeshProUGUI dialogueText; // The dialogue area
    public GameObject dialogueObject;    // The entire dialogue area
    private Queue<string> sentences;     // All of the text for multiple lines of text
    private bool seen;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        seen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        dialogueObject.SetActive(true);
        if (!seen) // If this is your first time talking
            foreach (string sentence in dialogue.sentences)
                sentences.Enqueue(sentence);
        else // After that new sentences come out
            foreach (string sentence in dialogue.newSentences)
                sentences.Enqueue(sentence);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        { // If the sentences run out put it away
            EndDialogue();
            return;
        }

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
        seen = true;
    }
}
