using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "InventorySystem/Items/Food")]
public class FoodObject : ItemObject
{
    public int restoreHealthValue;

    public void Awake()
    {
        type = ItemType.Food;
    }
}