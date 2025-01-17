using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteKnight : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.white | ChessPieceType.knight;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteKnight");

    readonly int[,] knightMoves = new int[,]
    {
        { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
        { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
    };

    public IEnumerable<int> GetAvailablePositions()
    {
        List<int> availablePositions = new();
        int currentPosition = GameManager.GetPosition(this);

        int height = currentPosition / 8;
        int width = currentPosition % 8;

        for (int i = 0; i < knightMoves.GetLength(0); i++)
        {
            int newHeight = height + knightMoves[i, 0];
            int newWidth = width + knightMoves[i, 1];

            if (newHeight >= 0 && newHeight <= 7 && newWidth >= 0 && newWidth <= 7)
            {
                int newPosition = newHeight * 8 + newWidth;

                // case: empty
                if (GameManager.chessPieces[newPosition] == null)
                    availablePositions.Add(newPosition);
                // case: capture
                else if ((GameManager.chessPieces[newPosition].GetComponent<ChessPiece>().piece.ChessPieceType
                     & ChessPieceType.black) == ChessPieceType.black)
                    availablePositions.Add(newPosition);
            }
        }

        return availablePositions;
    }

}
