using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteQueen : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.white | ChessPieceType.queen;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteQueen");

    public IEnumerable<int> GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
