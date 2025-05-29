using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject seeScore;
    public GameObject allScoresPanel;


    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void SeeScore()
    {
        mainMenu.SetActive(false);
        seeScore.SetActive(true);
    }

    public void GoBackToMenu()
    {
        mainMenu.SetActive(true);
        seeScore.SetActive(false);
    }
    public void SeeAllScores()
    {
        mainMenu.SetActive(false);
        allScoresPanel.SetActive(true);
    }

    public void BackFromAllScores()
    {
        allScoresPanel.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
