using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameObject Controller;

    private int xBoard = -1;
    private int yBoard = -1;

    public Sprite black_pawn, black_bishop, black_king;
    public Sprite white_pawn, white_bishop, white_king;


    public void Activate()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "black_pawn":
                this.GetComponent<SpriteRenderer>().sprite = black_pawn; break;
            case "black_bishop":
                this.GetComponent<SpriteRenderer>().sprite = black_bishop; break;
            case "black_king":
                this.GetComponent <SpriteRenderer>().sprite = black_king; break;
            case "white_pawn":
                this.GetComponent<SpriteRenderer>().sprite = white_pawn; break;
            case "white_bishop":
                this.GetComponent<SpriteRenderer>().sprite = white_bishop; break;
            case "white_king":
                this.GetComponent<SpriteRenderer>().sprite = white_king; break;
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
}
