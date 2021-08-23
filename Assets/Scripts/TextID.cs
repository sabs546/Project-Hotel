using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextID : MonoBehaviour
{
    public GameObject interaction;           // The actual interaction object that needs activating
    public GameObject questInteraction;      // The interaction if you have the right thing equipped
    public List<GameObject> backupText;      // The text for after you've investigated it once
    public List<GameObject> questBackupText; // The text after you speak once the quest is completed
    public int itemID;
    public bool questCheck;
    public int questItem;
    public bool removeQuestItem;
    [HideInInspector]
    public bool active;
    private int textChain;                   // How many times have you read it
    private TextMeshProUGUI text;
    private TextMeshProUGUI questText;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        textChain = 0;
        text = interaction.GetComponentInChildren<TextMeshProUGUI>();
        if (questInteraction != null)
        {
            questText = questInteraction.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteraction(bool setting)
    {
        active = setting;
        if (questInteraction != null && questCheck)
        {
            questInteraction.SetActive(active);
        }
        else
        {
            interaction.SetActive(active);
        }
    }

    public void ChangeText()
    {
        if (questInteraction != null && questCheck)
        {
            if (textChain < questBackupText.Capacity)
            { // As long as you don't run out of backup text, keep going
                questText.text = questBackupText[textChain].GetComponent<TextMeshProUGUI>().text;
                textChain++;
            }
        }
        else
        {
            if (textChain < backupText.Capacity)
            { // As long as you don't run out of backup text, keep going
                text.text = backupText[textChain].GetComponent<TextMeshProUGUI>().text;
                textChain++;
            }
        }
    }
}
