using UnityEngine;

public class GrowBlock : MonoBehaviour
{
    [SerializeField] Sprite soilTilledSprite;
    [SerializeField] Sprite soilWateredSprite;

    SpriteRenderer spriteRendererSoil;
    SpriteRenderer spriteRendererPlant;
    private CellData cellData;

    public void Bind(CellData data)
    {
        if (cellData != null)
            cellData.OnChanged -= UpdateVisual;

        cellData = data;
        cellData.OnChanged += UpdateVisual;
        UpdateVisual();
    }

    void OnDestroy()
    {
        if (cellData != null)
            cellData.OnChanged -= UpdateVisual;
    }

    void Awake()
    {
        spriteRendererSoil = GetComponent<SpriteRenderer>();
        spriteRendererPlant = transform.Find("Plant").GetComponent<SpriteRenderer>(); 
    }

    void UpdateVisual()
    {
        if(cellData.CellType != CellType.soil) return;

        if(cellData.IsWatered)
            {spriteRendererSoil.sprite = soilWateredSprite;} 
        else 
            {spriteRendererSoil.sprite = soilTilledSprite;}
        spriteRendererPlant.sprite = null;

        if(cellData.SeedData == null) return;
        
        if (cellData.CurrentStage == SoilStage.planted)
        {
            spriteRendererPlant.sprite = cellData.SeedData.cropPlanted;
        } 
        else if (cellData.CurrentStage == SoilStage.growing1)
        {
            spriteRendererPlant.sprite = cellData.SeedData.cropGrowing1;
        }
        else if (cellData.CurrentStage == SoilStage.growing2)
        {
            spriteRendererPlant.sprite = cellData.SeedData.cropGrowing2;
        }
        else if (cellData.CurrentStage == SoilStage.growing3)
        {
            spriteRendererPlant.sprite = cellData.SeedData.cropGrowing3;
        }
        else if (cellData.CurrentStage == SoilStage.ripe)
        {
            spriteRendererPlant.sprite = cellData.SeedData.cropRipe;
        }
    }
}