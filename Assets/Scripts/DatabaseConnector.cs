using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using MySql.Data.MySqlClient;


public class DatabaseConnector : MonoBehaviour
{
    private static bool isInitialized = false;
    private string connectionString;

    public static string currentPlayer;

    public GameObject username_field;
    public GameObject password_field;

    public TextMeshProUGUI errorMsg;

    public TextMeshProUGUI usernameMsg;
    public TextMeshProUGUI passwordMsg;

    // Start is called before the first frame update
    void Start()
    {
        if (isInitialized) return;
        isInitialized = true;

        connectionString = "Server=localhost;Database=Unity2D;User ID=root;Pooling=false;";
        DataManager.instance.clearErrorMessage();

        DataManager.instance.registerUser += RegisterUser;
        DataManager.instance.loginUser += LoginUser;

    }

    public bool LoginUser()
    {
        DataManager.instance.clearErrorMessage();
        string username = DataManager.instance.username;
        string password = DataManager.instance.password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            DataManager.instance.ErrorMessage("You must fill username and password!");
        }

        if (!string.IsNullOrEmpty(DataManager.instance.errorMessage))
        {
            DataManager.instance.login = false;
            return false;
        }
           

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (MySqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username"; 
                command.Parameters.AddWithValue("@Username", username);
                var result = Convert.ToInt32(command.ExecuteScalar());

                if (result <= 0)
                {
                    DataManager.instance.ErrorMessage("Username not found!");
                    DataManager.instance.login = false;
                    return false;
                }
                else
                {
                    command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password ";
                    command.Parameters.AddWithValue("@Password", password);
                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result <= 0)
                    {
                        DataManager.instance.ErrorMessage("Password is incorrect!");
                        DataManager.instance.login = false;
                        return false;

                    }
                    else
                    {
                        DataManager.instance.login = true;
                        return true;
                    }
                }

            }
            
        }
        
    }

 

    public bool RegisterUser()
    {
        Debug.Log("RegisterUser called");
        DataManager.instance.clearErrorMessage();

        string username = DataManager.instance.username;
        string password = DataManager.instance.password;
        string confirmPassword = DataManager.instance.confirmPassword;

        if (string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password))
        {
            DataManager.instance.ErrorMessage("You must fill username and password!");
        }

        if(confirmPassword != password)
        {
            DataManager.instance.ErrorMessage("Passwords must match!");
            
        }
        if (!string.IsNullOrEmpty(DataManager.instance.errorMessage))
        {
            Debug.Log(DataManager.instance.errorMessage);
            DataManager.instance.register = false;
            return false;
        }
           
            


        
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (MySqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    command.ExecuteNonQuery();
                    DataManager.instance.register = true;
                    return true;
                }
                catch(MySqlException e) 
                {
                    DataManager.instance.ErrorMessage(e.Message);
                    DataManager.instance.register = false;
                    return false;
                }
            }
        }
        
        
    }

}