using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("Menu"); //LoadScene when button is clicked
    }

    public void start()
    {
        SceneManager.LoadScene("Teste_scene_(Kevin)"); //LoadScene when button is clicked
    }

    public void quitGame()
    {
        Application.Quit(); //Quit Game button
        //UnityEditor.EditorApplication.isPlaying = false; //Quit Game in Unity Editor
    }

}
