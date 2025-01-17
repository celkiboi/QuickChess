using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteKing : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.white | ChessPieceType.king;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteKing");

    readonly int[,] kingDirections = new int[,]
{
    { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 },
    { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 }
};

    public IEnumerable<int> GetAvailablePositions()
    {
        List<int> availablePositions = new();
        int currentPosition = GameManager.GetPosition(this);

        int height = currentPosition / 8;
        int width = currentPosition % 8;

        for (int d = 0; d < kingDirections.GetLength(0); d++)
        {
            int newHeight = height + kingDirections[d, 0];
            int newWidth = width + kingDirections[d, 1];

            if (newHeight >= 0 && newHeight <= 7 && newWidth >= 0 && newWidth <= 7)
            {
                int newPosition = newHeight * 8 + newWidth;

                // case: empty or capture
                if (GameManager.chessPieces[newPosition] == null ||
                    (GameManager.chessPieces[newPosition].GetComponent<ChessPiece>().piece.ChessPieceType
                     & ChessPieceType.black) == ChessPieceType.black)
                {
                    availablePositions.Add(newPosition);
                }
            }
        }

        return availablePositions;
    }

}
