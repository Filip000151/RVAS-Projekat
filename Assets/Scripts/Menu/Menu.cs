using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject seeScore;
    public GameObject allScoresPanel;

    private GameObject MusicPlayer;

    public void Start()
    {
        MusicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
    }

    public void SeeScore()
    {
        mainMenu.SetActive(false);
        seeScore.SetActive(true);
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
    }

    public void GoBackToMenu()
    {
        mainMenu.SetActive(true);
        seeScore.SetActive(false);
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
    }
    public void SeeAllScores()
    {
        seeScore.SetActive(false);
        allScoresPanel.SetActive(true);
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
    }

    public void BackFromAllScores()
    {
        allScoresPanel.SetActive(false);
        mainMenu.SetActive(true);
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
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
