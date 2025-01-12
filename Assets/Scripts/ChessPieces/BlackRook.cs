using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackRook : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.black & ChessPieceType.rook;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackRook");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
