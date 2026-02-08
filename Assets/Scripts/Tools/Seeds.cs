using UnityEngine;

public class Seeds : Seed
{ 
    [SerializeField] private SeedSO seedSO;
    CellData cellData;
    Vector2Int cellPos;
    

    public override bool StartingUsing(CellUseContext cellUseContext)
    {
        cellData = cellUseContext.cellData;
        cellPos = cellUseContext.cell;

        return CropSeeds();
    }

    private bool CropSeeds()
    {
        if(cellData.CellType == CellType.soil && cellData.CurrentStage == SoilStage.ploughed && cellData.SeedData == null)
        {
            cellData.SeedData = seedSO;
            cellData.CurrentStage = SoilStage.planted;
            return true;
        }
        return false;
    }

    public override void FinishUsing(){}
}