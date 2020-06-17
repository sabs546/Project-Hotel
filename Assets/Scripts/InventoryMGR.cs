using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMGR : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonArea;
    public GameObject imageArea;
    public GameObject descriptionArea;
    public Sprite[] imageStash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(int itemID)
    {
        // Item and buttons
        Item item = FindItem(itemID);
        item.GenerateItem(ref item);
        GameObject tempButton = button;

        // Setting button value
        tempButton.GetComponentInChildren<Text>().text = item.name;
        Instantiate(button, buttonArea.transform);

        // Setting inventory values
        imageArea.GetComponent<Image>().sprite = imageStash[item.ID];
        descriptionArea.GetComponent<TextMeshProUGUI>().text = item.description;
    }

    private Item FindItem(int itemID)
    {
        switch (itemID)
        {
            case 0:
                return new GenericItem();
        }
        return new GenericItem();
    }
}
