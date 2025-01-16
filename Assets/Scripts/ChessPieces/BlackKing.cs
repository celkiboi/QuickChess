using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackKing : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.black | ChessPieceType.king;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackKing");

    public IEnumerable<int> GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
