using TMPro;
using UnityEngine;

public class ItemInventoryAmountDisplay : MonoBehaviour
{
    public TextMeshProUGUI textGUI;
    private int _itemAmount;

    public int ItemAmount
    {
        get => _itemAmount;
        set
        {
            _itemAmount = value;
            if (_itemAmount == 0)
                textGUI.text = "";
            else
                textGUI.text = _itemAmount.ToString();
        }
    }

    private void OnValidate()
    {
        if (textGUI == null) textGUI = GetComponent<TextMeshProUGUI>();
        if (_itemAmount != 0)
            textGUI.text = _itemAmount.ToString();
    }
}