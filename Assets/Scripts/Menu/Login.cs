using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField u;
    [SerializeField] TMP_InputField p;
    public string username = "";
    public string password = "";

    public void LoginUser()
    {
        //provera za username i password
        
        if(username.Length < 1 || password.Length < 1)
        {
            Debug.LogError("You must fill the username and password fields");
            return;
        } 

        Transform parent = transform.parent;
        parent.GetChild(1).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Username(string username)
    {
        this.username = u.text; 
    }
    public void Password(string password)
    {
        this.password = p.text;
    }
    
}
