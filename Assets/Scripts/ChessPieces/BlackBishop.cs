using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackBishop : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.black & ChessPieceType.bishop;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackBishop");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
