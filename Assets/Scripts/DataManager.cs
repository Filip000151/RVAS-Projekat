using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region singleton 
        public static DataManager instance;
    void Awake() {
        if (instance != null) { 
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion 
    public delegate bool RegisterUser();
    public event RegisterUser registerUser;
    public delegate bool LoginUser();
    public event LoginUser loginUser;
    public string username, password, confirmPassword;

    public bool login, register;

    public bool OnUserRegister()
    {
        registerUser.Invoke();
        foreach (RegisterUser handler in registerUser.GetInvocationList())
        {
            return handler();

        }
        return false;
        //return GetComponent<DatabaseConnector>().RegisterUser();

    }

    public bool OnUserLogin()
    {
        loginUser.Invoke();
        foreach (LoginUser handler in loginUser.GetInvocationList())
        {
            return handler();

        }
        return false;
        //return GetComponent<DatabaseConnector>().LoginUser();
    }
    public string errorMessage { get; private set; }
    public void ErrorMessage(string message)
    {
        errorMessage += message + "\n";
    }
    /// <summary>
    /// Pozovi svaki put  pre konektovanja na bazu 
    /// i posle svake konekcije.
    /// </summary>
    public void clearErrorMessage()
    {
        errorMessage = string.Empty;
    }

    public bool DbCheck ()
    {
        if (string.IsNullOrEmpty(errorMessage))
        {
            return true;
        }
        return false;
    }


}
