using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextID : MonoBehaviour
{
    public GameObject interaction;
    public List<GameObject> backupText;
    public int itemID;
    [HideInInspector]
    public bool active;
    private int textChain;
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
        {
            text.text = backupText[textChain].GetComponent<TextMeshProUGUI>().text;
            textChain++;
        }
    }
}
