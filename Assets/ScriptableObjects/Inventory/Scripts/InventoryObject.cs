using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InventoryObject : ScriptableObject , ISerializationCallbackReceiver
{
    //public List<InventorySlot> Container = new List<InventorySlot>();
    public Inventory Container;
    public ItemDatabaseObject Database;

    [Tooltip("Always start with a /")]
    public string savePath;
    
    public void AddItem(ItemObject item, int amount)
    {
        for (var i = 0; i < Container.Items.Count; ++i)
        {
            if (Container.Items[i].item == item)
            {
                Container.Items[i].AddAmount(amount);
                return;
            }
        }

        Container.Items.Add(new InventorySlot(Database.GetId[item], item, amount));
    }

    public void OnBeforeSerialize()
    {
        // new NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Items.Count; ++i)
        {
            Container.Items[i].item = Database.GetItem[Container.Items[i].ID];
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log("Saving inventory");
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            Debug.Log("Loading inventory...");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }
}

[Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;

    public InventorySlot(int id, ItemObject item, int amount)
    {
        this.ID = id;
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}