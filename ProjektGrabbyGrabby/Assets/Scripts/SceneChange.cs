using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public InitializeAds initializeAds;

    public void Awake()
    {
        initializeAds = GameObject.Find("InitializeAds").GetComponent<InitializeAds>();
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void start()
    {
        initializeAds.bannerView.Hide();
        SceneManager.LoadScene("Teste_scene_(Kevin)"); //LoadScene when button is clicked
    }

    public void quitGame()
    {
        Application.Quit(); //Quit Game button
        //UnityEditor.EditorApplication.isPlaying = false; //Quit Game in Unity Editor
    }

}
