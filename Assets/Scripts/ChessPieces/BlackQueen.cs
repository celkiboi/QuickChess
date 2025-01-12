using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackQueen : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.black & ChessPieceType.queen;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackQueen");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
