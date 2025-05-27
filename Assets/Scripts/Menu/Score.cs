using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        int wins = DataManager.instance.winCount;
        int losses = DataManager.instance.loseCount;

        scoreText.text = $"Wins: {wins}\nLosses: {losses}";
    }
}
