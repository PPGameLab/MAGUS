using System.Collections.Generic;
[System.Serializable]
public class Item
{
    public string itemName; // Имя предмета
    public string itemID; // Уникальный идентификатор
    public string description; // Описание предмета
    public ItemRarity rarity; // Редкость предмета
    public string itemSet; // Название сета (если принадлежит к сету)
    public List<ItemBonus> bonuses; // Список бонусов, которые даёт предмет

    // Конструктор для удобного создания предметов
    public Item(string name, string id, string description, ItemRarity rarity, string itemSet, List<ItemBonus> bonuses)
    {
        this.itemName = name;
        this.itemID = id;
        this.description = description;
        this.rarity = rarity;
        this.itemSet = itemSet;
        this.bonuses = bonuses;
    }
}

// Перечисление для редкости предметов
public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
[System.Serializable]
public class ItemBonus
{
    public string bonusType; // Например, "strength", "vampirism", "moveSpeed"
    public float bonusValue; // Значение бонуса
    public ValueType valueType; // Тип значения: Числовое или Процентное

    // Конструктор
    public ItemBonus(string type, float value, ValueType valueType)
    {
        this.bonusType = type;
        this.bonusValue = value;
        this.valueType = valueType;
    }
}

// Перечисление для типа значения бонуса
public enum ValueType
{
    Flat, // Числовое значение (например, +5 к силе)
    Percentage // Процентное значение (например, +10% к вампиризму)
}
