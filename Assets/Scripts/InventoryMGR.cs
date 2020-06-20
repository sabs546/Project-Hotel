using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMGR : MonoBehaviour
{
    public GameObject button;          // The button for the item
    public GameObject buttonArea;      // The parent for the button
    public GameObject imageArea;       // The image box
    public GameObject descriptionArea; // The description box
    public Sprite[] imageStash;        // All the item images
    public Sprite emptyImage;          // When nothing is selected
    public bool fullHide;              // When the box is all the way down
    private Image image;               // The area for the image to be placed
    private TextMeshProUGUI text;      // The description area for the item
    // Start is called before the first frame update
    void Start()
    {
        image = imageArea.GetComponent<Image>();
        text = descriptionArea.GetComponent<TextMeshProUGUI>();
        image.preserveAspect = true;
        fullHide = false;
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
        tempButton.GetComponent<InventoryButton>().itemID = item.ID;
        Instantiate(button, buttonArea.transform);
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

    public void ShowItem(int itemID)
    { // When you click an item it appears on the display
        Item item = FindItem(itemID);
        item.GenerateItem(ref item);
        image.sprite = imageStash[itemID];
        text.text = item.description;
    }

    public void HideItem()
    { // Put it away when you re-click the button
        image.sprite = emptyImage;
        text.text = "";
    }

    public void FullHide()
    { // Hide it when the inventory is put away
        fullHide = true;
        image.sprite = emptyImage;
        text.text = "";
    }
}
