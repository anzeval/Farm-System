
using System;

public enum CellType
{
    ground,
    soil,
    grass
}

public enum SoilStage
{
    barren,
    ploughed,
    planted,
    growing1,
    growing2,
    growing3,
    ripe
}

public class CellData
{
    public event Action OnChanged;

    private CellType cellType = CellType.ground;
    public CellType CellType
    {
        get => cellType;
        set
        {
            if (cellType == value) return;
            cellType = value;
            OnChanged?.Invoke();
        }
    }

    private SeedSO seedData = null;
    public SeedSO SeedData
    {
        get => seedData;
        set
        {
            if (seedData == value) return;
            seedData = value;
            OnChanged?.Invoke();
        }
    }

    private ICellEntity entity = null;
    public ICellEntity Entity
    {
        get => entity;
        set
        {
            if (entity == value) return;
            entity = value;
        }
    }

    private SoilStage currentStage = SoilStage.barren;
    public SoilStage CurrentStage
    {
        get => currentStage;
        set
        {
            if (currentStage == value) return;
            currentStage = value;
            OnChanged?.Invoke();
        }
    }

    //timers for grow system
    public float growthTimer = 0;
    public float timeToNextStage = 10f;

    // soil
    private bool isWatered = false;
    public bool IsWatered
    {
        get => isWatered;
        set
        {
            if (isWatered == value) return;
            isWatered = value;
            OnChanged?.Invoke();
        }
    }
   
    private int fertility = 1;
    public int Fertility
    {
        get => fertility;
        set
        {
            if (fertility == value) return;
            fertility = value;
            OnChanged?.Invoke();
        }
    }

    //resources
    public bool isBlocked = false;
}
