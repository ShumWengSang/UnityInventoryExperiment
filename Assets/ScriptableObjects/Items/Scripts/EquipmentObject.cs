using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "InventorySystem/Items/Item")]
public class EquipmentObject : ItemObject
{
    public float atkBonus;

    private void Awake()
    {
        type = ItemType.Equipment;
    }
}