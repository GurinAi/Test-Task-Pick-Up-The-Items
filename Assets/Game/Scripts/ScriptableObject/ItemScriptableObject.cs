using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
}

public enum ItemType
{
    Default,
    Food,
    Figure
}