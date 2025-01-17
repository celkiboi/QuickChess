using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WhiteQueen : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.white | ChessPieceType.queen;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/WhiteQueen");

    readonly int[,] queenDirections = new int[,]
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

        for (int d = 0; d < queenDirections.GetLength(0); d++)
        {
            int directionHeight = queenDirections[d, 0];
            int directionWidth = queenDirections[d, 1];

            int newHeight = height + directionHeight;
            int newWidth = width + directionWidth;

            while (newHeight >= 0 && newHeight <= 7 && newWidth >= 0 && newWidth <= 7)
            {
                int newPosition = newHeight * 8 + newWidth;

                // case: empty
                if (GameManager.chessPieces[newPosition] == null)
                {
                    availablePositions.Add(newPosition);
                }
                else
                {
                    // case: capture
                    if ((GameManager.chessPieces[newPosition].GetComponent<ChessPiece>().piece.ChessPieceType
                         & ChessPieceType.black) == ChessPieceType.black)
                    {
                        availablePositions.Add(newPosition);
                    }
                    break;
                }

                newHeight += directionHeight;
                newWidth += directionWidth;
            }
        }

        return availablePositions;
    }

}
