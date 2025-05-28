using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameObject Controller;
    public GameObject MovePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    public Sprite black_pawn, black_bishop, black_king;
    public Sprite white_pawn, white_bishop, white_king;

    private string player;

    public int attack;
    public int health;


    public void Activate()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "black_pawn":
                this.GetComponent<SpriteRenderer>().sprite = black_pawn;
                player = "black";
                attack = 2;
                health = 3;
                break;
            case "black_bishop":
                this.GetComponent<SpriteRenderer>().sprite = black_bishop;
                player = "black";
                attack = 3;
                health = 4;
                break;
            case "black_king":
                this.GetComponent <SpriteRenderer>().sprite = black_king;
                player = "black";
                attack = 2;
                health = 8;
                break;
            case "white_pawn":
                this.GetComponent<SpriteRenderer>().sprite = white_pawn;
                player = "white";
                attack = 2;
                health = 3;
                break;
            case "white_bishop":
                this.GetComponent<SpriteRenderer>().sprite = white_bishop;
                player = "white";
                attack = 3;
                health = 4;
                break;
            case "white_king":
                this.GetComponent<SpriteRenderer>().sprite = white_king;
                player = "white";
                attack = 2;
                health = 8;
                break;
        }
    }


    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1.28f;
        y *= 1.28f;

        x -= 3.84f;
        y -= 3.84f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    public void OnMouseUp()
    {
        DestroyMovePlates();

        InitializeMovePlates();
    }

    public void DestroyMovePlates()
    {
        GameObject[] MovePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < MovePlates.Length; i++)
        {
            Destroy(MovePlates[i]);
        }
    }

    public void InitializeMovePlates()
    {
        switch (this.name)
        {
            case "black_pawn":
                PawnMovePlate(xBoard, yBoard - 1);
                PawnMovePlate(xBoard + 1, yBoard - 1);
                PawnMovePlate(xBoard - 1, yBoard - 1);
                break;
            case "white_pawn":
                PawnMovePlate(xBoard, yBoard + 1);
                PawnMovePlate(xBoard + 1, yBoard + 1);
                PawnMovePlate(xBoard - 1, yBoard + 1);
                break;
            case "black_bishop":
            case "white_bishop":
                LMovePlate();
                break;
            case "black_king":
            case "white_king":
                SurroundMovePlate();
                break;
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard + 2, yBoard - 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard);
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
    }

    public void PointMovePlate(int x, int y)
    {
        GameController gc = Controller.GetComponent<GameController>();

        if(gc.PositionOnBoard(x, y))
        {
            GameObject ChessPiece = gc.GetPosition(x, y);

            if(ChessPiece == null)
            {
                MovePlateSpawn(x, y);
            }
            else if(ChessPiece.GetComponent<PieceController>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y)
    {
        GameController gc = Controller.GetComponent<GameController>();
        
        if(gc.PositionOnBoard(x, y))
        {
            GameObject ChessPiece = gc.GetPosition(x, y);

            if(ChessPiece == null)
            {
                MovePlateSpawn(x, y);
            }
            else if(ChessPiece.GetComponent <PieceController>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1.28f;
        y *= 1.28f;

        x -= 3.84f;
        y -= 3.84f;

        GameObject mp = Instantiate(MovePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1.28f;
        y *= 1.28f;

        x -= 3.84f;
        y -= 3.84f;

        GameObject mp = Instantiate(MovePlate, new Vector3(x, y, -1.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.AttackMode = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public string GetPlayer()
    {
        return player;
    }
}
