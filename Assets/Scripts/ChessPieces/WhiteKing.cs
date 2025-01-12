using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteKing : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.white & ChessPieceType.king;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteKing");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
