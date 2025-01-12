using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackPawn : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.black & ChessPieceType.pawn;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackPawn");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
