using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameController : MonoBehaviour
{
    public GameObject ChessPiece;
    private GameObject[,] Positions = new GameObject[7, 7];
    private GameObject[] PlayerBlack = new GameObject[7];
    private GameObject[] PlayerWhite = new GameObject[7];

    private string CurrentPlayer = "white";


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



    
    
}
