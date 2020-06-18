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
    public Sprite emptyImage;
    public bool fullHide; // When the box is all the way down
    private Image image;
    private TextMeshProUGUI text;
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
    {
        Item item = FindItem(itemID);
        item.GenerateItem(ref item);
        image.sprite = imageStash[itemID];
        text.text = item.description;
    }

    public void HideItem()
    {
        image.sprite = emptyImage;
        text.text = "";
    }

    public void FullHide()
    {
        fullHide = true;
        image.sprite = emptyImage;
        text.text = "";
    }
}
