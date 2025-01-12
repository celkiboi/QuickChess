using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject WhiteTilePrefab;
    [SerializeField]
    GameObject BlackTilePrefab;

    GameObject[] tiles;

    void Start()
    {
        tiles = new GameObject[64];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject tilePrefab = (i + j) % 2 == 0 ? WhiteTilePrefab : BlackTilePrefab;
                Vector3 position = new(j, i, 0);

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);

                tiles[i *  8 + j] = tile;
            }
        }
    }
}
