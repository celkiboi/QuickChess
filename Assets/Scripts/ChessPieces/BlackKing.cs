using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackKing : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.black & ChessPieceType.king;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackKing");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
