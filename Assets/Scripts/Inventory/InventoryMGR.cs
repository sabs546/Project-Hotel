using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryMGR : MonoBehaviour
{
    public  GameObject      button;          // The button for the item
    public  GameObject      buttonArea;      // The parent for the button
    public  GameObject      imageArea;       // The image box
    public  GameObject      descriptionArea; // The description box
    public  Sprite[]        imageStash;      // All the item images
    public  Sprite          emptyImage;      // When nothing is selected
    public  bool            fullHide;        // When the box is all the way down
    [HideInInspector]
    public  int             equippedItem;    // Which item is equipped

    private Image           image;           // The area for the image to be placed
    private TextMeshProUGUI text;            // The description area for the item

    // Start is called before the first frame update
    void Start()
    {
        image = imageArea.GetComponent<Image>();
        text = descriptionArea.GetComponent<TextMeshProUGUI>();
        image.preserveAspect = true;
        fullHide = false;
        equippedItem = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(int itemID)
    {
        // Item and buttons
        Storage.inventory.Add(itemID);
        Item item = FindItem(itemID);
        item.GenerateItem(ref item);

        // Setting button value
        button.GetComponentInChildren<Text>().text = item.name;
        button.GetComponent<InventoryButton>().itemID = itemID;
        Instantiate(button, buttonArea.transform);
    }

    public void RemoveItem()
    {
        foreach (InventoryButton button in buttonArea.GetComponentsInChildren<InventoryButton>().Where(n => n.itemID == equippedItem))
        {
            Destroy(button.gameObject);
            equippedItem = -1;
            HideItem();
            Storage.inventory.Remove(button.itemID);
        }
    }

    private Item FindItem(int itemID)
    {
        switch (itemID)
        {
            case 0:
                return new GenericItem();
            case 1:
                return new MoneyItem();
            case 2:
                return new OrangeItem();
            case 3:
                return new OddCheeseItem();
            case 4:
                return new BikeBookItem();
        }
        return new GenericItem();
    }

    public void ShowItem(int itemID)
    { // When you click an item it appears on the display
        Item item = FindItem(itemID);
        item.GenerateItem(ref item);
        image.sprite = itemID > -1 ? imageStash[itemID] : emptyImage;
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
