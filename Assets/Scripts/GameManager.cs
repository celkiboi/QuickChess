using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject WhiteTilePrefab;
    [SerializeField]
    GameObject BlackTilePrefab;
    [SerializeField]
    GameObject ChessPiecePrefab;
    [SerializeField]
    TextMeshProUGUI blackName;
    [SerializeField]
    TextMeshProUGUI whiteName;
    [SerializeField]
    TextMeshProUGUI turn;
    [SerializeField]
    TextMeshProUGUI blackTime;
    [SerializeField]
    TextMeshProUGUI whiteTime;
    [SerializeField]
    TextMeshProUGUI mainText;

    GameObject[] tiles;
    public static GameObject[] chessPieces;

    Socket socket;
    static GameManager instance;

    private string username = "";
    private string IP = "";
    private int port = 0;

    readonly string yourTurn = "Your turn";
    readonly string opponentTurn = "Opponent turn";

    bool isOnTurn = false;
    bool isWhite = true;
    ChessPieceType color;
    bool hasEnded = false;
    bool hasWon = false;
    int whiteMinutesRemaining = 5;
    int whiteSecondsRemaining = 5;
    int blackMinutesRemaining = 5;
    int blackSecondsRemaining = 5;
    int selectedIndex = -1;
    int previousSelectedIndex = -1;
    int selectedPieceIndex = -1;

    void LoadConfig()
    {
        string filePath = Path.Combine(Application.dataPath, "../optcli.txt");

        if (File.Exists(filePath))
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 3)
                {
                    username = lines[0].Trim();
                    IP = lines[1].Trim();
                    port = int.Parse(lines[2].Trim());
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error loading config file: {e.Message}");
            }
        }
        else
        {
            Debug.LogError("Configuration file not found.");
        }
    }

    public void Start()
    {
        instance = this;
        LoadConfig();

        socket = new();

        socket.Connect(IP, port);
        socket.SendData(Encoding.UTF8.GetBytes(username));

        tiles = new GameObject[64];
        chessPieces = new GameObject[64];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject tilePrefab = (i + j) % 2 == 0 ? WhiteTilePrefab : BlackTilePrefab;
                Vector3 position = new(j, i, 0);

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);

                tiles[i * 8 + j] = tile;
            }
        }

        mainText.text = "Waiting for an opponent to join...";

        chessPieces[0] = Instantiate(ChessPiecePrefab, tiles[0].transform.position, Quaternion.identity);
        chessPieces[0].GetComponent<ChessPiece>().Activate(new WhiteRook());
        chessPieces[0].transform.Translate(new(0, 0, -0.05f));

        chessPieces[1] = Instantiate(ChessPiecePrefab, tiles[1].transform.position, Quaternion.identity);
        chessPieces[1].GetComponent<ChessPiece>().Activate(new WhiteKnight());
        chessPieces[1].transform.Translate(new(0, 0, -0.05f));

        chessPieces[2] = Instantiate(ChessPiecePrefab, tiles[2].transform.position, Quaternion.identity);
        chessPieces[2].GetComponent<ChessPiece>().Activate(new WhiteBishop());
        chessPieces[2].transform.Translate(new(0, 0, -0.05f));

        chessPieces[3] = Instantiate(ChessPiecePrefab, tiles[3].transform.position, Quaternion.identity);
        chessPieces[3].GetComponent<ChessPiece>().Activate(new WhiteQueen());
        chessPieces[3].transform.Translate(new(0, 0, -0.05f));

        chessPieces[4] = Instantiate(ChessPiecePrefab, tiles[4].transform.position, Quaternion.identity);
        chessPieces[4].GetComponent<ChessPiece>().Activate(new WhiteKing());
        chessPieces[4].transform.Translate(new(0, 0, -0.05f));

        chessPieces[5] = Instantiate(ChessPiecePrefab, tiles[5].transform.position, Quaternion.identity);
        chessPieces[5].GetComponent<ChessPiece>().Activate(new WhiteBishop());
        chessPieces[5].transform.Translate(new(0, 0, -0.05f));

        chessPieces[6] = Instantiate(ChessPiecePrefab, tiles[6].transform.position, Quaternion.identity);
        chessPieces[6].GetComponent<ChessPiece>().Activate(new WhiteKnight());
        chessPieces[6].transform.Translate(new(0, 0, -0.05f));

        chessPieces[7] = Instantiate(ChessPiecePrefab, tiles[7].transform.position, Quaternion.identity);
        chessPieces[7].GetComponent<ChessPiece>().Activate(new WhiteRook());
        chessPieces[7].transform.Translate(new(0, 0, -0.05f));

        for (int i = 8; i < 16; i++)
        {
            chessPieces[i] = Instantiate(ChessPiecePrefab, tiles[i].transform.position, Quaternion.identity);
            chessPieces[i].GetComponent<ChessPiece>().Activate(new WhitePawn());
            chessPieces[i].transform.Translate(new(0, 0, -0.05f));
        }

        for (int i = 48; i < 56; i++)
        {
            chessPieces[i] = Instantiate(ChessPiecePrefab, tiles[i].transform.position, Quaternion.identity);
            chessPieces[i].GetComponent<ChessPiece>().Activate(new BlackPawn());
            chessPieces[i].transform.Translate(new(0, 0, -0.05f));
        }

        chessPieces[56] = Instantiate(ChessPiecePrefab, tiles[56].transform.position, Quaternion.identity);
        chessPieces[56].GetComponent<ChessPiece>().Activate(new BlackRook());
        chessPieces[56].transform.Translate(new(0, 0, -0.05f));

        chessPieces[57] = Instantiate(ChessPiecePrefab, tiles[57].transform.position, Quaternion.identity);
        chessPieces[57].GetComponent<ChessPiece>().Activate(new BlackKnight());
        chessPieces[57].transform.Translate(new(0, 0, -0.05f));

        chessPieces[58] = Instantiate(ChessPiecePrefab, tiles[58].transform.position, Quaternion.identity);
        chessPieces[58].GetComponent<ChessPiece>().Activate(new BlackBishop());
        chessPieces[58].transform.Translate(new(0, 0, -0.05f));

        chessPieces[59] = Instantiate(ChessPiecePrefab, tiles[59].transform.position, Quaternion.identity);
        chessPieces[59].GetComponent<ChessPiece>().Activate(new BlackQueen());
        chessPieces[59].transform.Translate(new(0, 0, -0.05f));

        chessPieces[60] = Instantiate(ChessPiecePrefab, tiles[60].transform.position, Quaternion.identity);
        chessPieces[60].GetComponent<ChessPiece>().Activate(new BlackKing());
        chessPieces[60].transform.Translate(new(0, 0, -0.05f));

        chessPieces[61] = Instantiate(ChessPiecePrefab, tiles[61].transform.position, Quaternion.identity);
        chessPieces[61].GetComponent<ChessPiece>().Activate(new BlackBishop());
        chessPieces[61].transform.Translate(new(0, 0, -0.05f));

        chessPieces[62] = Instantiate(ChessPiecePrefab, tiles[62].transform.position, Quaternion.identity);
        chessPieces[62].GetComponent<ChessPiece>().Activate(new BlackKnight());
        chessPieces[62].transform.Translate(new(0, 0, -0.05f));

        chessPieces[63] = Instantiate(ChessPiecePrefab, tiles[63].transform.position, Quaternion.identity);
        chessPieces[63].GetComponent<ChessPiece>().Activate(new BlackRook());
        chessPieces[63].transform.Translate(new(0, 0, -0.05f));

        PlayGame();
    }

    async Task PlayGame()
    {
        byte[] opponentNameBytes = await socket.ReceiveData();
        string opponentName = GetStringFromByteArray(opponentNameBytes);

        mainText.gameObject.SetActive(false);
        blackTime.gameObject.SetActive(true);
        whiteTime.gameObject.SetActive(true);
        blackName.gameObject.SetActive(true);
        whiteName.gameObject.SetActive(true);

        socket.SendData(Encoding.UTF8.GetBytes("OK"));

        byte[] colorBytes = await socket.ReceiveData();
        Protocol communicationValue = ConvertFromByteArray(colorBytes);
        isWhite = Protocol.startGameWhite == communicationValue;

        blackName.text = (!isWhite) ? username : opponentName;
        whiteName.text = (isWhite) ? username : opponentName;
        turn.text = (isWhite) ? yourTurn : opponentTurn;
        isOnTurn = isWhite;
        color = (isWhite) ? ChessPieceType.white : ChessPieceType.black;

        StartCoroutine(SubtractTime());
        ListenToEnemy();
    }

    async Task ListenToEnemy()
    {
        while(true)
        {
            byte[] data = await socket.ReceiveData();
            Protocol info = ConvertFromByteArray(data);
            ChangePiecePosition(info);
            isOnTurn = true;
        }
    }

    Protocol ConvertFromByteArray(byte[] info)
    {
        return (Protocol)((info[0] << 8) | info[1]);
    }

    string GetStringFromByteArray(byte[] info)
    {
        return Encoding.UTF8.GetString(info);
    }

    void UpdateTimer(bool isWhiteTimer)
    {
        if (isWhiteTimer)
        {
            if (whiteSecondsRemaining == 0)
            {
                whiteSecondsRemaining = 60;
                whiteMinutesRemaining--;
            }
            whiteSecondsRemaining--;
        }
        else
        {
            if (blackSecondsRemaining == 0)
            {
                blackSecondsRemaining = 60;
                blackMinutesRemaining--;
            }
            blackSecondsRemaining--;
        }
    }

    IEnumerator SubtractTime()
    {
        while (true)
        {
            if (isOnTurn)
            {
                UpdateTimer(isWhite);
            }
            else
            {
                UpdateTimer(!isWhite);
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void Update()
    {
        if (hasEnded)
            return;

        whiteTime.text = (whiteSecondsRemaining < 10)
            ? $"{whiteMinutesRemaining}:0{whiteSecondsRemaining}"
            : $"{whiteMinutesRemaining}:{whiteSecondsRemaining}";

        blackTime.text = (blackSecondsRemaining < 10)
            ? $"{blackMinutesRemaining}:0{blackSecondsRemaining}"
            : $"{blackMinutesRemaining}:{blackSecondsRemaining}";

        if (isWhite && whiteMinutesRemaining == 0 && whiteSecondsRemaining == 0)
        {
            socket.SendData(Protocol.endGame.ToBytes());
            hasEnded = true;
        }
        if (!isWhite && blackMinutesRemaining == 0 && blackSecondsRemaining == 0)
        {
            socket.SendData(Protocol.endGame.ToBytes());
            hasEnded = true;
        }
        if (hasEnded)
        {
            blackTime.gameObject.SetActive(false);
            whiteTime.gameObject.SetActive(false);
            blackName.gameObject.SetActive(false);
            whiteName.gameObject.SetActive(false);
            mainText.gameObject.SetActive(true);
            mainText.text = (hasWon) ? "You won!" : "You lost!";
        }

        if (!isOnTurn)
            return;

        if (selectedIndex != -1 && selectedIndex != previousSelectedIndex 
            && tiles[selectedIndex].GetComponent<Tile>().IsMovable)
        {
            ChangePiecePosition(selectedPieceIndex, selectedIndex);
            SendMoveInfo(selectedPieceIndex, selectedIndex);
            selectedPieceIndex = -1;
            selectedIndex = -1;
            isOnTurn = false;
        }

        if (selectedIndex != -1 && selectedIndex != previousSelectedIndex 
            && ((chessPieces[selectedIndex]?.GetComponent<ChessPiece>().piece.ChessPieceType
            & color) != 0))
        {
            UnMarkAllTiles();
            IEnumerable<int> availablePositions = chessPieces[selectedIndex]?
                .GetComponent<ChessPiece>().piece.GetAvailablePositions();
            
            MarkTilesAsMovable(availablePositions);

            previousSelectedIndex = selectedIndex;
        }

        if (previousSelectedIndex != selectedIndex)
            UnMarkAllTiles();
    }

    private void UnMarkAllTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == null) continue;
            tiles[i].GetComponent<Tile>().SetAsNormal();
        }
    }

    private void MarkTilesAsMovable(IEnumerable<int> availablePositions)
    {
        if (availablePositions is null)
            return;
        foreach (int position in availablePositions)
        {
            tiles[position].GetComponent<Tile>().MarkAsMovable();
        }
    }

    public static int GetPosition(IChessPiece piece)
    {
        for (int i = 0; i < chessPieces.Length; i++)
        {
            if (chessPieces[i] == null) continue;
            if (piece == chessPieces[i].GetComponent<ChessPiece>().piece)
                return i;
        }

        return -1;
    }

    void ChangePiecePosition(int start, int end)
    {
        // case: capture
        if (chessPieces[end] != null)
        {
            Destroy(chessPieces[end]);
        }

        int height = start / 8;
        // Case: forward en passants (by a white)
        if (height == 4)
        {
            // Case: en passant left-up (by a white)
            if (start - 1 >= 0 && start - 1 < chessPieces.Length
                && chessPieces[start] != null && chessPieces[start - 1] != null
                && (chessPieces[start].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.white | ChessPieceType.pawn)) // is a white pawn
                && (chessPieces[start - 1].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.black | ChessPieceType.pawn)) // is a black pawn
                && (end - start == 7)) // has moved forward left
            {
                Destroy(chessPieces[start - 1]);
            }
            // Case: en passant right-up (by a white)
            else if (start + 1 >= 0 && start + 1 < chessPieces.Length
                && chessPieces[start] != null && chessPieces[start + 1] != null
                && (chessPieces[start].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.white | ChessPieceType.pawn)) // is a white pawn
                && (chessPieces[start + 1].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.black | ChessPieceType.pawn)) // is a black pawn
                && (end - start == 9)) // has moved forward right
            {
                Destroy(chessPieces[start + 1]);
            }
        }
        // Case: backwards en passants (by a black)
        else if (height == 3)
        {
            // Case: en passant left-down (by a black)
            if (start - 1 >= 0 && start - 1 < chessPieces.Length
                && chessPieces[start] != null && chessPieces[start - 1] != null
                && (chessPieces[start].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.black | ChessPieceType.pawn)) // is a black pawn
                && (chessPieces[start - 1].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.white | ChessPieceType.pawn)) // is a white pawn
                && (start - end == 9)) // has moved backwards left
            {
                Destroy(chessPieces[start - 1]);
            }
            // Case: en passant right-down (by a black)
            else if (start + 1 >= 0 && start + 1 < chessPieces.Length
                && chessPieces[start] != null && chessPieces[start + 1] != null
                && (chessPieces[start].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.black | ChessPieceType.pawn)) // is a black pawn
                && (chessPieces[start + 1].GetComponent<ChessPiece>().piece.ChessPieceType == (ChessPieceType.white | ChessPieceType.pawn)) // is a white pawn
                && (start - end == 7)) // has moved backwards right
            {
                Destroy(chessPieces[start + 1]);
            }
        }



        chessPieces[end] = chessPieces[start];
        chessPieces[start] = null;
        chessPieces[end].transform.position = tiles[end].transform.position;
        chessPieces[end].transform.Translate(new(0, 0, -0.05f));
    }

    void ChangePiecePosition(Protocol info)
    {
        int start = (int)(info & Protocol.startPosition);
        int end = (int)((Protocol)info & Protocol.endPosition) >> 6;
        ChangePiecePosition(start, end);
    }

    public static void Clicked(GameObject tile)
    {
        for(int i = 0; i < instance.tiles.Length; i++)
        {
            if (tile == instance.tiles[i])
            {
                instance.selectedIndex = i;
                // if the selected tile had a piece of the same color, mark it as a selected piece
                // not doing the color check means that "capturing" opponent pieces bugs the game
                if (chessPieces[instance.selectedIndex] != null &&
                    (chessPieces[instance.selectedIndex].GetComponent<ChessPiece>().piece
                    .ChessPieceType & instance.color) == instance.color)
                    instance.selectedPieceIndex = i;
                return;
            }
        }
        instance.selectedIndex = -1;
    }

    void SendMoveInfo(int start, int end)
    {
        Protocol info = Protocol.startPosition & (Protocol)start;
        info = info | (Protocol.endPosition & ((Protocol)(end << 6)));

        byte[] data = new byte[2];
        data[0] = (byte)info;
        data[1] = (byte)((int)info >> 8);

        socket.SendData(data);
    }
}
