using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackKnight : IChessPiece
{
    public string CurrentLocation { get; set; }

    public ChessPieceType ChessPieceType => ChessPieceType.black & ChessPieceType.knight;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackKnight");

    public string[] GetAvailablePositions()
    {
        throw new NotImplementedException();
    }
}
