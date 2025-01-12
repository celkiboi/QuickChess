using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhitePawn : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.white & ChessPieceType.pawn;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhitePawn");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
