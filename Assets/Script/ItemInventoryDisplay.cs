using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryDisplay : MonoBehaviour
{
    public Image image;
    private ItemObject _item;

    public ItemObject Item
    {
        get => _item;
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
                image.sprite = _item.ItemUI;
            }
        }
    }

    private void OnValidate()
    {
        if (image == null) image = GetComponent<Image>();

        if (_item != null)
            image.sprite = Item.ItemUI;
    }
}