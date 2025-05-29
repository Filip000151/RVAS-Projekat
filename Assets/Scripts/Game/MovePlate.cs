using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject Controller;

    GameObject Reference = null;

    int matrixX;
    int matrixY;

    public bool AttackMode = false;

    public void Start()
    {
        if (AttackMode)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");

        if (AttackMode)
        {
            GameObject ChessPiece = Controller.GetComponent<GameController>().GetPosition(matrixX, matrixY);

            ChessPiece.GetComponent<PieceController>().health -= Reference.GetComponent<PieceController>().attack;
            Reference.GetComponent<PieceController>().health -= ChessPiece.GetComponent<PieceController>().attack;

            if (Reference.GetComponent<PieceController>().health <= 0 && ChessPiece.GetComponent<PieceController>().health <= 0)
            {
                Destroy(ChessPiece);
                Destroy(Reference);

                Reference.GetComponent<PieceController>().DestroyMovePlates();

                Controller.GetComponent<GameController>().SetPositionEmpty(ChessPiece.GetComponent<PieceController>().GetXBoard(), ChessPiece.GetComponent<PieceController>().GetYBoard());
                Controller.GetComponent<GameController>().SetPositionEmpty(Reference.GetComponent<PieceController>().GetXBoard(), Reference.GetComponent<PieceController>().GetYBoard());

                if ((ChessPiece.name == "white_king" || ChessPiece.name == "black_king") && (Reference.name == "black_king" || Reference.name == "white_king"))
                    Controller.GetComponent<GameController>().Winner("Draw");
                else if (ChessPiece.name == "white_king") Controller.GetComponent<GameController>().Winner("black");
                else if (ChessPiece.name == "black_king") Controller.GetComponent<GameController>().Winner("white");
                else if (Reference.name == "white_king") Controller.GetComponent<GameController>().Winner("black");
                else if (Reference.name == "black_king") Controller.GetComponent<GameController>().Winner("white");
            }
            else if (ChessPiece.GetComponent<PieceController>().health <= 0)
            {
                Destroy(ChessPiece);

                Controller.GetComponent<GameController>().SetPositionEmpty(Reference.GetComponent<PieceController>().GetXBoard(), Reference.GetComponent<PieceController>().GetYBoard());

                Reference.GetComponent<PieceController>().SetXBoard(matrixX);
                Reference.GetComponent<PieceController>().SetYBoard(matrixY);
                Reference.GetComponent<PieceController>().SetCoords();

                Reference.GetComponent<PieceController>().HasMovedThisTurn = true;
                Controller.GetComponent<GameController>().SetPosition(Reference);

                Reference.GetComponent<PieceController>().DestroyMovePlates();

                if (ChessPiece.name == "white_king") Controller.GetComponent<GameController>().Winner("black");
                else if (ChessPiece.name == "black_king") Controller.GetComponent<GameController>().Winner("white");
            }
            else if (Reference.GetComponent<PieceController>().health <= 0)
            {
                Destroy(Reference);

                Reference.GetComponent<PieceController>().DestroyMovePlates();

                Controller.GetComponent<GameController>().SetPositionEmpty(Reference.GetComponent<PieceController>().GetXBoard(), Reference.GetComponent<PieceController>().GetYBoard());

                if (Reference.name == "white_king") Controller.GetComponent<GameController>().Winner("black");
                else if (Reference.name == "black_king") Controller.GetComponent<GameController>().Winner("white");
            }
            else
            {
                Reference.GetComponent<PieceController>().DestroyMovePlates();
                Reference.GetComponent<PieceController>().HasMovedThisTurn = true;
            }
        }
        else
        {
            Controller.GetComponent<GameController>().SetPositionEmpty(Reference.GetComponent<PieceController>().GetXBoard(), Reference.GetComponent<PieceController>().GetYBoard());

            Reference.GetComponent<PieceController>().SetXBoard(matrixX);
            Reference.GetComponent<PieceController>().SetYBoard(matrixY);

            Reference.GetComponent<PieceController>().SetCoords();

            Controller.GetComponent<GameController>().SetPosition(Reference);

            Reference.GetComponent<PieceController>().HasMovedThisTurn = true;
            Reference.GetComponent<PieceController>().DestroyMovePlates();
        }


        
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        Reference = obj;
    }

    public GameObject GetReference()
    {
        return Reference;
    }
}
