using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public IChessPiece piece { get; private set; }

    public void Activate(IChessPiece piece)
    {
        this.piece = piece;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = piece.Sprite;
    }
}
