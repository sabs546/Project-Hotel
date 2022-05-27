using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextID : MonoBehaviour
{
    [HideInInspector]
    public bool active;
    public Interaction[] interactions;
    public int currentDialogueOption;

    private int textChain;                   // How many times have you read it
    private int questTextChain;              // How many times have you read it
    private TextMeshProUGUI text;
    private TextMeshProUGUI questText;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        textChain = 0;
        questTextChain = 0;
        if (interactions.Length > 0)
        {
            foreach (Interaction i in interactions)
            {
                i.text = i.interaction.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
        currentDialogueOption = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteraction(bool setting)
    {
        active = setting;
        interactions[currentDialogueOption].interaction.SetActive(active);
    }

    public void ChangeText()
    {
        if (textChain < interactions[currentDialogueOption].backupText.Capacity)
        {
            interactions[currentDialogueOption].text.text = interactions[currentDialogueOption].backupText[textChain].GetComponent<TextMeshProUGUI>().text;
            textChain++;
        }
    }

    public void ChangeDialogueOption(int number)
    {
        currentDialogueOption = number;
    }
}

[System.Serializable]
public class Interaction
{
    public GameObject interaction;      // The interaction if you have the right thing equipped
    public List<GameObject> backupText; // The text after you speak once
    public int droppedItemID;           // ID of an item you're given
    public bool checkCompletion;        // Check if the quest is complete
    public int requiredItemID;          // Item needed to complete the quest
    public bool removeRequiredItem;     // Do they take the quest item away?
    [HideInInspector]
    public TextMeshProUGUI text;
    public BaseTask task;
}