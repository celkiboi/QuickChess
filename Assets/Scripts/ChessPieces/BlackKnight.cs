using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackKnight : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.black | ChessPieceType.knight;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackKnight");

    public IEnumerable<int> GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
