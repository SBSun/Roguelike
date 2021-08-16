using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height ; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(transform.position.x + x + 0.5f, transform.position.y + y + 0.5f), Quaternion.identity, transform);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }
    }

    private void Update()
    {

        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Debug.Log(hit.collider.name);
        }

    }
}
