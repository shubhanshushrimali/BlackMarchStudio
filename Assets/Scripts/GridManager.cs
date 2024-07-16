using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    public int gridSize = 10;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                tile.name = $"Tile {x}, {y}";
                tile.AddComponent<TileInfo>().SetPosition(x, y);
            }
        }
    }
}

public class TileInfo : MonoBehaviour
{
    public int x;
    public int y;

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
