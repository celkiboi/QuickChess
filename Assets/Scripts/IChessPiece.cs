using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IChessPiece
{
    public IEnumerable<int> GetAvailablePositions();

    ChessPieceType ChessPieceType { get; }

    Sprite Sprite { get; }
}
