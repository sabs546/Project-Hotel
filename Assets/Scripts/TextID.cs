using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextID : MonoBehaviour
{
    public GameObject interaction;      // The actual interaction object that needs activating
    public List<GameObject> backupText; // The text for after you've investigated it once
    public int itemID;
    [HideInInspector]
    public bool active;
    private int textChain;              // How many times have you read it
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        textChain = 0;
        text = interaction.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteraction(bool setting)
    {
        active = setting;
        interaction.SetActive(active);
    }

    public void ChangeText()
    {
        if (textChain < backupText.Capacity)
        { // As long as you don't run out of backup text, keep going
            text.text = backupText[textChain].GetComponent<TextMeshProUGUI>().text;
            textChain++;
        }
    }
}
