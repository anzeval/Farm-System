using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ProcGeneration : MonoBehaviour
{
    [SerializeField] int spawnInterval = 1;
    [SerializeField] float spawnChance = 1f;
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] GridController gridController; 

    Dictionary<Vector2Int, CellData> cells = new Dictionary<Vector2Int, CellData>();

    void Start()
    {
        StartCoroutine(SpawnGrassRoutine());
    }

    private IEnumerator SpawnGrassRoutine()
    {
        while (true)
        {
            foreach (var cell in cells)
            {
                if (!isCellAvailable(cell.Value)) continue;
                if(Random.value > spawnChance) continue;

                GameObject grassGO = Instantiate(spawnPrefab, gridController.CellToWorld(cell.Key), Quaternion.identity, transform);

                GrassEntity grassEntity = grassGO.GetComponent<GrassEntity>();
                cell.Value.Entity = grassEntity;
                cell.Value.CellType = CellType.grass; 
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private bool isCellAvailable(CellData cellData)
    {
        return cellData.CellType == CellType.ground;
    }
    
    public void TakeData(Dictionary<Vector2Int, CellData> data)
    {
        cells = data;
    }
}
