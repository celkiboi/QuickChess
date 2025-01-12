using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteRook : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.white & ChessPieceType.rook;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteRook");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
