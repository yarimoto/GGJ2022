using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public Tilemap walkableTilemap;
    BoundsInt bounds;

    // Start is called before the first frame update
    void Start()
    {
        walkableTilemap.CompressBounds();
        bounds = walkableTilemap.cellBounds;
   }

    public void CreateGrid()
    {
        var spots = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < bounds.size.x; x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < bounds.size.y; y++, j++)
            {
                if (walkableTilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    spots[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    spots[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        walkableTilemap.WorldToCell(player.transform.position);
    }
}
