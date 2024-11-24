using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    // Метод для добавления предмета в инвентарь
    public void AddItem(ItemScriptableObject item, int quantity = 1)
    {
        // Проверка: если предмет уже существует, добавляем количество
        ItemSlot slot = itemSlots.Find(s => s.item == item);
        if (slot != null)
        {
            slot.quantity += quantity;
        }
        else
        {
            itemSlots.Add(new ItemSlot(item, quantity));
        }
    }

    // Метод для удаления предмета
    public void RemoveItem(ItemScriptableObject item, int quantity = 1)
    {
        ItemSlot slot = itemSlots.Find(s => s.item == item);
        if (slot != null)
        {
            slot.quantity -= quantity;
            if (slot.quantity <= 0)
            {
                itemSlots.Remove(slot);
            }
        }
    }
}

// Класс для описания слота инвентаря
[System.Serializable]
public class ItemSlot
{
    public ItemScriptableObject item;
    public int quantity;

    public ItemSlot(ItemScriptableObject item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
