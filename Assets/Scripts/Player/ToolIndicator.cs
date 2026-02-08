using UnityEngine;
using UnityEngine.InputSystem;

public class ToolIndicator : MonoBehaviour
{
    [SerializeField] GridController gridController;
    [SerializeField] Camera camera;
    SpriteRenderer spriteRenderer;

    public Vector2Int currentCell {get; private set;}
    public bool IsCellInRange {get; private set;}

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateIndicator();
    }

    private void UpdateIndicator()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = -camera.transform.position.z;
        mousePos = camera.ScreenToWorldPoint(mousePos);

        Vector2Int cell = gridController.WorldToCell(mousePos);
        Vector3 cellCenter = gridController.CellToWorld(cell);

        if (gridController.IsCellInRange(cell))
        {
            spriteRenderer.enabled = true;
            IsCellInRange = true;
        } else
        {
            spriteRenderer.enabled = false;
            IsCellInRange = false;
        }

        currentCell = cell;
        transform.position = cellCenter;
    }
}
