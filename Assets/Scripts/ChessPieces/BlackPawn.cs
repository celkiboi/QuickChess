using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlackPawn : IChessPiece
{
    public ChessPieceType ChessPieceType => ChessPieceType.black | ChessPieceType.pawn;

    public Sprite Sprite => Resources.Load<Sprite>("SpriteImages/BlackPawn");

    public IEnumerable<int> GetAvailablePositions()
    {
        List<int> availablePositions = new();
        int currentPosition = GameManager.GetPosition(this);

        int height = currentPosition / 8;
        int width = currentPosition % 8;

        // case: beggining
        if (height == 6 && GameManager.chessPieces[5 * 8 + width] == null)
        {
            availablePositions.Add(5 * 8 + width);
            if (GameManager.chessPieces[4 * 8 + width] == null)
                availablePositions.Add(4 * 8 + width);
        }
        // case: forward
        else if (height > 0 && GameManager.chessPieces[(height - 1) * 8 + width] == null)
        {
            availablePositions.Add((height - 1) * 8 + width);
        }
        // case: capture right
        if (height > 0 && width < 7 && GameManager.chessPieces[(height - 1) * 8 + width + 1] != null)
        {
            if ((GameManager.chessPieces[(height - 1) * 8 + width + 1].GetComponent<ChessPiece>().piece.ChessPieceType
                & ChessPieceType.white) == ChessPieceType.white)
                availablePositions.Add((height - 1) * 8 + width + 1);
        }
        // case: capture left
        if (height > 0 && width > 0 && GameManager.chessPieces[(height - 1) * 8 + width - 1] != null)
        {
            if ((GameManager.chessPieces[(height - 1) * 8 + width - 1].GetComponent<ChessPiece>().piece.ChessPieceType
                & ChessPieceType.white) == ChessPieceType.white)
                availablePositions.Add((height - 1) * 8 + width - 1);
        }
        // case: en passant left
        if (height > 0 && width > 0 && GameManager.chessPieces[(height) * 8 + width - 1] != null
            && GameManager.chessPieces[(height - 1) * 8 + width - 1] == null)
        {
            if ((GameManager.chessPieces[(height) * 8 + width - 1].GetComponent<ChessPiece>().piece.ChessPieceType
                & ChessPieceType.white) == ChessPieceType.white)
                availablePositions.Add((height - 1) * 8 + width - 1);
        }
        // case: en passant right
        if (height > 0 && width < 7 && GameManager.chessPieces[(height) * 8 + width + 1] != null
            && GameManager.chessPieces[(height - 1) * 8 + width + 1] == null)
        {
            if ((GameManager.chessPieces[(height) * 8 + width + 1].GetComponent<ChessPiece>().piece.ChessPieceType
                & ChessPieceType.white) == ChessPieceType.white)
                availablePositions.Add((height - 1) * 8 + width + 1);
        }
        return availablePositions;
    }
}
