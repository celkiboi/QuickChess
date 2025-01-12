using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject WhiteTilePrefab;
    [SerializeField]
    GameObject BlackTilePrefab;
    [SerializeField]
    GameObject ChessPiecePrefab;

    GameObject[] tiles;
    List<GameObject> chessPieces;

    void Start()
    {
        tiles = new GameObject[64];
        chessPieces = new();

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

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[0].transform.position, Quaternion.identity));
        chessPieces[0].GetComponent<ChessPiece>().Activate(new WhiteRook());
        chessPieces[0].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[1].transform.position, Quaternion.identity));
        chessPieces[1].GetComponent<ChessPiece>().Activate(new WhiteKnight());
        chessPieces[1].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[2].transform.position, Quaternion.identity));
        chessPieces[2].GetComponent<ChessPiece>().Activate(new WhiteBishop());
        chessPieces[2].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[3].transform.position, Quaternion.identity));
        chessPieces[3].GetComponent<ChessPiece>().Activate(new WhiteQueen());
        chessPieces[3].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[4].transform.position, Quaternion.identity));
        chessPieces[4].GetComponent<ChessPiece>().Activate(new WhiteKing());
        chessPieces[4].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[5].transform.position, Quaternion.identity));
        chessPieces[5].GetComponent<ChessPiece>().Activate(new WhiteBishop());
        chessPieces[5].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[6].transform.position, Quaternion.identity));
        chessPieces[6].GetComponent<ChessPiece>().Activate(new WhiteKnight());
        chessPieces[6].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[7].transform.position, Quaternion.identity));
        chessPieces[7].GetComponent<ChessPiece>().Activate(new WhiteRook());
        chessPieces[7].transform.Translate(new(0, 0, -0.05f));

        for (int i = 8; i < 16; i++)
        {
            chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[i].transform.position, Quaternion.identity));
            chessPieces[i].GetComponent<ChessPiece>().Activate(new WhitePawn());
            chessPieces[i].transform.Translate(new(0, 0, -0.05f));
        }

        for (int i = 16; i < 24; i++)
        {
            chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[i + 32].transform.position, Quaternion.identity));
            chessPieces[i].GetComponent<ChessPiece>().Activate(new BlackPawn());
            chessPieces[i].transform.Translate(new(0, 0, -0.05f));
        }

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[56].transform.position, Quaternion.identity));
        chessPieces[24].GetComponent<ChessPiece>().Activate(new BlackRook());
        chessPieces[24].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[57].transform.position, Quaternion.identity));
        chessPieces[25].GetComponent<ChessPiece>().Activate(new BlackKnight());
        chessPieces[25].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[58].transform.position, Quaternion.identity));
        chessPieces[26].GetComponent<ChessPiece>().Activate(new BlackBishop());
        chessPieces[26].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[59].transform.position, Quaternion.identity));
        chessPieces[27].GetComponent<ChessPiece>().Activate(new BlackQueen());
        chessPieces[27].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[60].transform.position, Quaternion.identity));
        chessPieces[28].GetComponent<ChessPiece>().Activate(new BlackKing());
        chessPieces[28].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[61].transform.position, Quaternion.identity));
        chessPieces[29].GetComponent<ChessPiece>().Activate(new BlackBishop());
        chessPieces[29].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[62].transform.position, Quaternion.identity));
        chessPieces[30].GetComponent<ChessPiece>().Activate(new BlackKnight());
        chessPieces[30].transform.Translate(new(0, 0, -0.05f));

        chessPieces.Add(Instantiate(ChessPiecePrefab, tiles[63].transform.position, Quaternion.identity));
        chessPieces[31].GetComponent<ChessPiece>().Activate(new BlackRook());
        chessPieces[31].transform.Translate(new(0, 0, -0.05f));
    }
}
