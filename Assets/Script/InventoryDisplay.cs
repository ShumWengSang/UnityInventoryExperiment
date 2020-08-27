using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public InventoryObject InventoryObject;
    public ItemInventoryAmountDisplay[] AmountDisplay;
    public ItemInventoryDisplay[] ItemDisplay;

    public void Awake()
    {
        AmountDisplay = GetComponentsInChildren<ItemInventoryAmountDisplay>();
        ItemDisplay = GetComponentsInChildren<ItemInventoryDisplay>();

        BuildInventoryDisplay();
    }

    public void Update()
    {
        UpdateInventoryDisplay();
    }

    public void BuildInventoryDisplay()
    {
        var displayItems = AmountDisplay.Length;
        // Go through all objects in inventory and display them.
        for (var i = 0; i < displayItems; ++i)
            if (i < InventoryObject.Container.Items.Count)
            {
                AmountDisplay[i].ItemAmount = InventoryObject.Container.Items[i].amount;
                ItemDisplay[i].Item = InventoryObject.Container.Items[i].item;
            }
            else
            {
                AmountDisplay[i].ItemAmount = 0;
                ItemDisplay[i].Item = null;
            }
    }


    public void UpdateInventoryDisplay()
    {
        BuildInventoryDisplay();
    }
}