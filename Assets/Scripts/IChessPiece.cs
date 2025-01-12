using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IChessPiece
{
    public string CurrentLocation {  get; set; }

    public string[] GetAvailablePositions();

    ChessPieceType ChessPieceType { get; }

    Sprite Sprite { get; }
}
