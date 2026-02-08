using UnityEngine;

public enum ItemType
{
    Tool,
    Seed,
    Consumable,
    Resource
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public readonly int id;
    public ItemType ItemType;

    public Sprite Icon;

    public GameObject Prefab;
}


