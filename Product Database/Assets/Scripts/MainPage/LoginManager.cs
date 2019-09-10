using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class LoginManager : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button loginButton;

    private string password;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", password);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);  //access a page and get infor from it
        yield return www;

        if (www.text[0] == '0')
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void VerifiInputs()
    {
        loginButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    public void Register()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void Update()
    {
        Debug.Log(passwordField.text);
        passwordField.caretPosition = passwordField.text.Length;
        if (passwordField.text.Length >= 1 && passwordField.text[passwordField.text.Length-1] != '*')
        {
            password += passwordField.text[passwordField.text.Length - 1];
            passwordField.text = "";
            
            while (passwordField.text.Length < password.Length) passwordField.text += "*";
        }

        if (passwordField.text.Length < password.Length)
        {
            password.Remove(password.Length - 1);
        }
    }
}
