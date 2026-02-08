using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthSystem : MonoBehaviour
{
    [SerializeField] int checkInterval = 2;
    List<CellData> cellDatas;

    private void Awake() 
    {
        cellDatas = new List<CellData>();
    }

    void Start()
    {
        StartCoroutine(CheckCellsRoutine());
    }

    private IEnumerator CheckCellsRoutine()
    {
        while (true)
        {
            foreach (CellData cell in cellDatas)
            {
                if(cell.CurrentStage != SoilStage.ripe && cell.SeedData != null && cell.IsWatered == true)
                {
                    if(UpdateGrowthTimerAndCheck(cell))
                    {
                      AdvanceCellStage(cell);  
                    }
                }
            }
            yield return new WaitForSeconds(checkInterval);
        }
    }

    private bool UpdateGrowthTimerAndCheck(CellData cell)
    {
        if(cell.growthTimer < cell.timeToNextStage)
        {
            cell.growthTimer += checkInterval;
            return false;
        } 
        else
        {
           cell.growthTimer = 0;
            return true; 
        }
    }

    private void AdvanceCellStage(CellData cell)
    {
        switch (cell.CurrentStage)
        {
            case SoilStage.planted : cell.CurrentStage = SoilStage.growing1; break;
            case SoilStage.growing1 : cell.CurrentStage = SoilStage.growing2; break;
            case SoilStage.growing2 : cell.CurrentStage = SoilStage.growing3; break;
            case SoilStage.growing3 : cell.CurrentStage = SoilStage.ripe; break;
            default: break;
        }

        cell.IsWatered = false;
    }

    public void AddCellData(CellData cellData)
    {
        cellDatas.Add(cellData);
    }

    public void TakeData(List<CellData> data)
    {
        cellDatas = data;
    }
}