using System;
using UnityEngine;

[SelectionBaseAttribute]
public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnApplicationQuit()
    {
        //inventory.Container.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            inventory.Load();
        }
    }
}