using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteRook : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.white | ChessPieceType.rook;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteRook");

    public IEnumerable<int> GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
