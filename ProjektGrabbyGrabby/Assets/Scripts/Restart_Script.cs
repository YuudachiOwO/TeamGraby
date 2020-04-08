using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart_Script : MonoBehaviour
{

    public void Reset()
    {
        SceneManager.LoadScene("Teste_scene");
    }
}
