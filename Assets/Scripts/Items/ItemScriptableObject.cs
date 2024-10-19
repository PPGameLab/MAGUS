using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemID;
    public string description;
    public ItemRarity rarity;
    public string itemSet;
    public List<ItemBonus> bonuses;
    public Sprite itemIcon; // Иконка для отображения предмета в UI
}
