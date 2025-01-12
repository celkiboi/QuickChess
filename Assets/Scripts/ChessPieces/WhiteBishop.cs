using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteBishop : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.white & ChessPieceType.bishop;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteBishop");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
