using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{
    private InventoryMGR inventoryMGR;
    private Image itemImage;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMGR = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryMGR>();
        itemImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryMGR.equippedItem == -1)
        {
            itemImage.sprite = inventoryMGR.emptyImage;
        }
    }

    public void ChangeDisplay()
    {
        itemImage.sprite = inventoryMGR.equippedItem != -1 ? inventoryMGR.imageStash[inventoryMGR.equippedItem] : inventoryMGR.emptyImage;
    }
}
