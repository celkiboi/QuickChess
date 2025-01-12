using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteKnight : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.white & ChessPieceType.knight;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteKnight");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
