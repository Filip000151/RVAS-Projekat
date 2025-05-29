using UnityEngine;

public class TurnButton : MonoBehaviour
{
    public GameController gc;
    public void OnEndTurnClick()
    {
        gc.EndTurn();
    }
}
