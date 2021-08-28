using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject portrait;          // The portrait area of the guy (yet to be implemented)
    public TextMeshProUGUI nameText;     // The name area
    public TextMeshProUGUI dialogueText; // The dialogue area
    public GameObject dialogueObject;    // The entire dialogue area
    public int outputDelay;              // Speed speech is formed at
    [HideInInspector]
    public string currentSentence;

    private int backupOutputDelay;
    private Queue<string> sentences;     // All of the text for multiple lines of text
    private bool seen;
    private bool questSeen;

    // Start is called before the first frame update
    void Start()
    {
        backupOutputDelay = outputDelay;
        sentences = new Queue<string>();
        seen = false;
        questSeen = false;
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
        if (GetComponent<TextID>().questCheck)
        {
            if (!questSeen) // If this is your first time talking
                foreach (string sentence in dialogue.questSentences)
                    sentences.Enqueue(sentence);
            else // After that new sentences come out
                foreach (string sentence in dialogue.newQuestSentences)
                    sentences.Enqueue(sentence);
            questSeen = true;
            return;
        }

        if (!seen) // If this is your first time talking
            foreach (string sentence in dialogue.sentences)
                sentences.Enqueue(sentence);
        else // After that new sentences come out
            foreach (string sentence in dialogue.newSentences)
                sentences.Enqueue(sentence);
    }

    public void DisplayNextSentence(bool skip = false)
    {
        if (skip)
        {
            StopAllCoroutines();
            dialogueText.text = currentSentence;
            return;
        }

        if (sentences.Count == 0)
        { // If the sentences run out put it away
            EndDialogue();
            return;
        }

        currentSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence (string sentence)
    { // Display letters one by one
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            while (outputDelay > 0)
            {
                outputDelay--;
                yield return null;
            }
            outputDelay = backupOutputDelay;
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueObject.SetActive(false);
        seen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EndDialogue();
    }
}
