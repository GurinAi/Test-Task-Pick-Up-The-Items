using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;
    public GameObject itemMesh;
    public string itemName;
}

public enum ItemType
{
    Default,
    Food,
    Figure
}