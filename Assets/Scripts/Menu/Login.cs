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

    public void LoginUser()
    {
        //DataManager.instance.username = username;
        //DataManager.instance.password = password;

        //provera za username i password
        if (!DataManager.instance.DbCheck())
        {
            errorMessage.text = DataManager.instance.errorMessage;
            return;
        }
        if (DataManager.instance.OnUserLogin())
        {
            MenuSetter(1);
        }

    }

    public void RegisterUser()
    {
        MenuSetter(2);
    }

    public void Register()
    {
        //DataManager.instance.username = username;
        //DataManager.instance.password = password;
        //DataManager.instance.confirmPassword = confirmPassword;

        if (!DataManager.instance.DbCheck())
        {
            errorMessage.text = DataManager.instance.errorMessage;
            return;
        }
        if (DataManager.instance.OnUserRegister())
        {
            MenuSetter();
        }
   
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
    }


    
}
