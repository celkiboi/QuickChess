using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Flags]
public enum ChessPieceType
{
    empty = 0,
    pawn = 1,
    rook = 2,
    knight = 4,
    bishop = 8,
    queen = 16,
    king = 32,

    white = 0x10000000,
    black = 0x01000000
}
