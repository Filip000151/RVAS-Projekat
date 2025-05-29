using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class GameController : MonoBehaviour
{
    public GameObject ChessPiece;
    private GameObject[,] Positions = new GameObject[7, 7];
    private GameObject[] PlayerBlack = new GameObject[7];
    private GameObject[] PlayerWhite = new GameObject[7];

    private string CurrentPlayer = "white";

    private bool TurnInProgress = true;
    private bool TurnFinished = false;
    private bool GameOver = false;

    public TextMeshProUGUI TurnText;




    void Start()
    {
        PlayerWhite = new GameObject[]
        {
            Create("white_pawn",0,0),Create("white_pawn",1,0),Create("white_bishop",2,0),Create("white_king",3,0),Create("white_bishop",4,0),Create("white_pawn",5,0),Create("white_pawn",6,0)
        };

        PlayerBlack = new GameObject[]
        {
            Create("black_pawn",0,6),Create("black_pawn",1,6),Create("black_bishop",2,6),Create("black_king",3,6),Create("black_bishop",4,6),Create("black_pawn",5,6),Create("black_pawn",6,6)
        };

        for(int i = 0; i<PlayerBlack.Length; i++)
        {
            SetPosition(PlayerBlack[i]);
            SetPosition(PlayerWhite[i]);
        }
        UpdateTurnText();
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(ChessPiece, new Vector3(0,0,-1), Quaternion.identity);
        PieceController pc = obj.GetComponent<PieceController>();
        pc.name = name;
        pc.SetXBoard(x);
        pc.SetYBoard(y);
        pc.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        PieceController pc = obj.GetComponent<PieceController>();
        Positions[pc.GetXBoard(), pc.GetYBoard()] = obj;

        
    }

    public void SetPositionEmpty(int x, int y)
    {
        Positions[x,y] = null;

    }

    public GameObject GetPosition(int x, int y)
    {
        return Positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if(x < 0 || y < 0 || x >= Positions.GetLength(0) || y >= Positions.GetLength(1))
        {
            return false;
        }
        else
        {
            return true;

        }
    }

    public string GetCurrentPlayer()
    {
        return CurrentPlayer;
    }

    public bool IsGameOver()
    {
        return GameOver;
    }

    public void NextTurn()
    {
        if(CurrentPlayer == "white")
        {
            CurrentPlayer = "black";
        }
        else
        {
            CurrentPlayer = "white";
        }
    }
    public void Update()
    {
        if(GameOver == true && Input.GetMouseButtonDown(0))
        {
            GameOver = false;
            SceneManager.LoadScene("Game");

        }
    }

    public void Winner(string PlayerWinner)
    {
        GameOver = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().enabled = true;
        if(PlayerWinner != "Draw")
        {
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().text = PlayerWinner + " is the winner!";

        }
        else
        {
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().text = PlayerWinner;
        }
        GameObject.FindGameObjectWithTag("EndText").GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public bool HasTurnFinished()
    {
        return TurnFinished;
    }

    public void StartTurn()
    {
        TurnFinished = false;
    }

    public bool IsTurnInProgress()
    {
        return TurnInProgress;
    }

    public void EndTurn()
    {
        NextTurn();
        UpdateTurnText();

        GameObject[] AllPieces = GameObject.FindGameObjectsWithTag("ChessPiece");
        foreach (GameObject piece in AllPieces)
        {
            PieceController pc = piece.GetComponent<PieceController>();
            if(pc != null && pc.GetPlayer() != CurrentPlayer)
            {
                pc.HasMovedThisTurn = false;

            }
        }
    }

    private void UpdateTurnText()
    {
        TurnText.text = $"{CurrentPlayer}'s turn:";
    }



}
