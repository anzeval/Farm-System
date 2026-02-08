using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] GrowBlock growBlockPrefab;
    [SerializeField] Transform player;
    [SerializeField] BoxCollider2D gridCollider;
    [SerializeField] LayerMask layerBlocker;
    [SerializeField] int cellRange;
    [SerializeField] GrowthSystem growthSystem;
    [SerializeField] ProcGeneration procGeneration;

    Dictionary<Vector2Int, CellData> cells = new Dictionary<Vector2Int, CellData>();
    List<CellData> cellDatas = new List<CellData>();

    Vector2Int gridOrigin;
    int gridHeight;
    int gridWidth;

    float cellSize = 1f;

    void Start()
    {
        GenerateGrid();
        growthSystem.TakeData(cellDatas);
        procGeneration.TakeData(cells);
    }

    private void GenerateGrid()
    {
        GetGridSize();

        for (int row = 0; row < gridHeight; row++)
        {
            for (int column = 0; column < gridWidth; column++)
            {
                Vector2Int cell = new Vector2Int(gridOrigin.x + column, gridOrigin.y + row );
                Vector3 worldPos = CellToWorld(cell);

                if (Physics2D.OverlapBox(worldPos, new Vector2(cellSize * 0.9f, cellSize * 0.9f), 0f, layerBlocker)) continue;

                cells.Add(cell, new CellData());
                CellData newCellData = cells[cell];
                GrowBlock growBlock = Instantiate(growBlockPrefab, worldPos, Quaternion.identity, transform );

                growBlock.Bind(newCellData);
                cellDatas.Add(newCellData);
            }
        }
    }

    private void GetGridSize()
    {
        int minX = Mathf.FloorToInt(gridCollider.bounds.min.x);
        int minY = Mathf.FloorToInt(gridCollider.bounds.min.y);
        int maxX = Mathf.CeilToInt(gridCollider.bounds.max.x);
        int maxY = Mathf.CeilToInt(gridCollider.bounds.max.y);

        gridHeight = maxY - minY;
        gridWidth = maxX - minX;
        gridOrigin = new Vector2Int(minX, minY);
    }

    public Vector2Int WorldToCell(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt((worldPos.x - gridOrigin.x) / cellSize);
        int y = Mathf.FloorToInt((worldPos.y - gridOrigin.y) / cellSize);

        return new Vector2Int(x + gridOrigin.x, y + gridOrigin.y);
    }

    public Vector3 CellToWorld(Vector2Int cell)
    {
        return new Vector3( cell.x + cellSize / 2f, cell.y + cellSize / 2f, 0f );
    }

    public bool IsCellInRange(Vector2Int cell)
    {
        return Vector3.Distance( CellToWorld(cell), player.position ) <= cellRange * cellSize + cellSize / 2f;
    }

    public CellData GetCell(Vector2Int cell)
    {
        cells.TryGetValue(cell, out CellData data);
        return data;
    }
}
