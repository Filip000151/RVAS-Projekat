using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField[] u = new TMP_InputField[2];
    [SerializeField] TMP_InputField[] p = new TMP_InputField[2];
    public string username = "";
    public string password = "";
    [Space, SerializeField] TextMeshProUGUI errorMessage;
    public string confirmPassword;
    [SerializeField] TMP_InputField c;

    private GameObject MusicPlayer;

    public void Start()
    {
        MusicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");

        if(DatabaseConnector.currentPlayer != null)
        {
            MenuSetter(1);
        }
    }

    public void LoginUser()
    {
        //DataManager.instance.username = username;
        //DataManager.instance.password = password;

        //provera za username i password
        DataManager.instance.clearErrorMessage();

        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();

        errorMessage.text = "";

        if (DataManager.instance.OnUserLogin())
        {
            MenuSetter(1);
        }
        else
        {
            errorMessage.text = DataManager.instance.errorMessage;
        }

    }

    public void RegisterUser()
    {
        MenuSetter(3);
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
    }

    public void Register()
    {
        //DataManager.instance.username = username;
        //DataManager.instance.password = password;
        //DataManager.instance.confirmPassword = confirmPassword;

        DataManager.instance.clearErrorMessage();
        errorMessage.text = "";

        if (DataManager.instance.OnUserRegister())
        {
            MenuSetter(1);
        }
        else
        {
            errorMessage.text = DataManager.instance.errorMessage;
        }

        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
   
    }
    public void Username(int id)
    {
        DataManager.instance.username = u[id].text; 
    }
    public void Password(int id)
    {
        DataManager.instance.password = p[id].text;
    }
    public void ConfirmPassword()
    {
        DataManager.instance.confirmPassword = c.text;
    }

    void MenuSetter(int id = 0)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(id).gameObject.SetActive(true);
    }

    public void BackButton()
    {
        MenuSetter();
        MusicPlayer.GetComponent<MusicPlayer>().PlayMenuButtonSound();
    }


    
}
