using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using MySql.Data.MySqlClient;

public class GameController : MonoBehaviour
{
    public GameObject ChessPiece;
    private GameObject[,] Positions = new GameObject[7, 7];
    private GameObject[] PlayerBlue = new GameObject[7];
    private GameObject[] PlayerRed = new GameObject[7];

    private string CurrentPlayer = "red";

    private bool TurnInProgress = true;
    private bool TurnFinished = false;
    private bool GameOver = false;

    public TextMeshProUGUI TurnText;

    private string connectionString;

    private AudioSource AudioSrc;
    public AudioClip PieceDestroyedSnd;
    public AudioClip PieceMovedSnd;
    public AudioClip PunchSnd;

    public AudioClip EndTurnSnd;
    public AudioClip VictorySnd;



    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();

        connectionString = "Server=localhost;Database=Unity2D;User ID=root;Pooling=false;";
        PlayerRed = new GameObject[]
        {
            Create("red_pawn",0,0),Create("red_pawn",1,0),Create("red_bishop",2,0),Create("red_king",3,0),Create("red_bishop",4,0),Create("red_pawn",5,0),Create("red_pawn",6,0)
        };

        PlayerBlue = new GameObject[]
        {
            Create("blue_pawn",0,6),Create("blue_pawn",1,6),Create("blue_bishop",2,6),Create("blue_king",3,6),Create("blue_bishop",4,6),Create("blue_pawn",5,6),Create("blue_pawn",6,6)
        };

        for(int i = 0; i<PlayerBlue.Length; i++)
        {
            SetPosition(PlayerBlue[i]);
            SetPosition(PlayerRed[i]);
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
        if(CurrentPlayer == "red")
        {
            CurrentPlayer = "blue";
        }
        else
        {
            CurrentPlayer = "red";
        }
    }
    public void Update()
    {
        if(GameOver == true && Input.GetMouseButtonDown(0))
        {
            GameOver = false;
            SceneManager.LoadScene("Menu");

        }
    }

    public void Winner(string PlayerWinner)
    {
        GameOver = true;
        PlayVictorySound();
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().enabled = true;
        if(PlayerWinner == "red")
        {
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().text = PlayerWinner + " is the winner!";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE users SET Win_count = Win_count + 1 WHERE Username = @username";
                    command.Parameters.AddWithValue("@username", DatabaseConnector.currentPlayer);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        else if(PlayerWinner == "blue")
        {
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().text = PlayerWinner + " is the winner!";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE users SET Lose_count = Lose_count + 1 WHERE Username = @username";
                    command.Parameters.AddWithValue("@username", DatabaseConnector.currentPlayer);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }


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
        PlayEndTurnSound();

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

    public void PlayPieceDestroyedSound()
    {
        AudioSrc.PlayOneShot(PieceDestroyedSnd);
    }

    public void PlayPieceMovedSound()
    {
        AudioSrc.PlayOneShot(PieceMovedSnd);
    }

    public void PlayPunchSound()
    {
        AudioSrc.PlayOneShot(PunchSnd);
    }

    public void PlayVictorySound()
    {
        AudioSrc.PlayOneShot(VictorySnd);
    }

    public void PlayEndTurnSound()
    {
        AudioSrc.PlayOneShot(EndTurnSnd);
    }



}
