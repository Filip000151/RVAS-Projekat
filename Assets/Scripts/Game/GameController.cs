using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ChessPiece;
    private GameObject[,] positions = new GameObject[7, 7];
    private GameObject[] PlayerBlack = new GameObject[7];
    private GameObject[] PlayerWhite = new GameObject[7];


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




    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(ChessPiece, new Vector3(0,0,-1), Quaternion.identity);
        return obj;
    }

    public void SetPosition(GameObject obj)
    {

    }



    
    
}
