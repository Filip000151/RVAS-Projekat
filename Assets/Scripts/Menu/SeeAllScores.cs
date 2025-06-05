using TMPro;
using UnityEngine;

public class SeeAllScores : MonoBehaviour
{
    public GameObject userRow;
    public Transform contentHolder;
    public GameObject connector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        connector = GameObject.FindGameObjectWithTag("DbManager");

        var users = connector.GetComponent<DatabaseConnector>().GetAllUsers();

        foreach (var user in users)
        {
            GameObject row = Instantiate(userRow, contentHolder);

            row.transform.Find("UsernameText").GetComponent<TextMeshProUGUI>().text = user.username;
            row.transform.Find("WinText").GetComponent<TextMeshProUGUI>().text = user.winCount.ToString();
            row.transform.Find("LossText").GetComponent<TextMeshProUGUI>().text = user.loseCount.ToString();
        }
    }
}
