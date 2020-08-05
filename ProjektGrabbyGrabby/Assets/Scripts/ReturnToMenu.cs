using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{

    public GameObject panel;

    public void CreditsOpen()
    {
        panel.SetActive(true);
    }

    public void CreditsClose()
    {
        panel.SetActive(false);
    }
}
