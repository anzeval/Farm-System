using UnityEngine;

public enum CropType
{
    pumpkin,
    cabbage,
    carrot,
    wheat,
    potato,
    strawberry,
    tomato,
    eggplant,
    onion,
    corn
}

[CreateAssetMenu(fileName = "SeedSO", menuName = "Scriptable Objects/SeedSO")]
public class SeedSO : ScriptableObject
{
    public CropType cropType;
    public ItemSO harvestItem;
    public int harvestAmount = 1;   

    public Sprite cropPlanted;
    public Sprite cropGrowing1;
    public Sprite cropGrowing2;
    public Sprite cropGrowing3;
    public Sprite cropRipe;
}
