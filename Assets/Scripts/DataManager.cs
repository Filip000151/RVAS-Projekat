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
