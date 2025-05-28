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
            GameObject cp = Controller.GetComponent<GameController>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }

        Controller.GetComponent<GameController>().SetPositionEmpty(Reference.GetComponent<PieceController>().GetXBoard(), Reference.GetComponent<PieceController>().GetYBoard());

        Reference.GetComponent<PieceController>().SetXBoard(matrixX);
        Reference.GetComponent<PieceController>().SetYBoard(matrixY);
        Reference.GetComponent<PieceController>().SetCoords();

        Controller.GetComponent<GameController>().SetPosition(Reference);

        Reference.GetComponent<PieceController>().DestroyMovePlates();
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
