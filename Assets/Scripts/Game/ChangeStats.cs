using UnityEngine;

public class ChangeStats : MonoBehaviour
{
    public Sprite[] Numbers;

    public GameObject ChessPiece;


    private void Start()
    {
        int health = GetComponentInParent<PieceController>().health;
        int attack = GetComponentInParent<PieceController>().attack;

        if(this.name == "Health")
        {
            switch (health)
            {
                case 0: this.GetComponent<SpriteRenderer>().sprite = Numbers[0]; break;
                case 1: this.GetComponent<SpriteRenderer>().sprite = Numbers[1]; break;
                case 2: this.GetComponent<SpriteRenderer>().sprite = Numbers[2]; break;
                case 3: this.GetComponent<SpriteRenderer>().sprite = Numbers[3]; break;
                case 4: this.GetComponent<SpriteRenderer>().sprite = Numbers[4]; break;
                case 5: this.GetComponent<SpriteRenderer>().sprite = Numbers[5]; break;
                case 6: this.GetComponent<SpriteRenderer>().sprite = Numbers[6]; break;
                case 7: this.GetComponent<SpriteRenderer>().sprite = Numbers[7]; break;
                case 8: this.GetComponent<SpriteRenderer>().sprite = Numbers[8]; break;
                case 9: this.GetComponent<SpriteRenderer>().sprite = Numbers[9]; break;
            }
        }
        else
        {
            switch (attack)
            {
                case 0: this.GetComponent<SpriteRenderer>().sprite = Numbers[0]; break;
                case 1: this.GetComponent<SpriteRenderer>().sprite = Numbers[1]; break;
                case 2: this.GetComponent<SpriteRenderer>().sprite = Numbers[2]; break;
                case 3: this.GetComponent<SpriteRenderer>().sprite = Numbers[3]; break;
                case 4: this.GetComponent<SpriteRenderer>().sprite = Numbers[4]; break;
                case 5: this.GetComponent<SpriteRenderer>().sprite = Numbers[5]; break;
                case 6: this.GetComponent<SpriteRenderer>().sprite = Numbers[6]; break;
                case 7: this.GetComponent<SpriteRenderer>().sprite = Numbers[7]; break;
                case 8: this.GetComponent<SpriteRenderer>().sprite = Numbers[8]; break;
                case 9: this.GetComponent<SpriteRenderer>().sprite = Numbers[9]; break;
            }
        }
    }

    private void Update()
    {
        int health = GetComponentInParent<PieceController>().health;

        if (this.name == "Health")
        {
            switch (health)
            {
                case 0: this.GetComponent<SpriteRenderer>().sprite = Numbers[0]; break;
                case 1: this.GetComponent<SpriteRenderer>().sprite = Numbers[1]; break;
                case 2: this.GetComponent<SpriteRenderer>().sprite = Numbers[2]; break;
                case 3: this.GetComponent<SpriteRenderer>().sprite = Numbers[3]; break;
                case 4: this.GetComponent<SpriteRenderer>().sprite = Numbers[4]; break;
                case 5: this.GetComponent<SpriteRenderer>().sprite = Numbers[5]; break;
                case 6: this.GetComponent<SpriteRenderer>().sprite = Numbers[6]; break;
                case 7: this.GetComponent<SpriteRenderer>().sprite = Numbers[7]; break;
                case 8: this.GetComponent<SpriteRenderer>().sprite = Numbers[8]; break;
                case 9: this.GetComponent<SpriteRenderer>().sprite = Numbers[9]; break;

            }
        }
    }
}
