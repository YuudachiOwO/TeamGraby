using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidTrip : MonoBehaviour
{
    public GameObject player;
    public GameObject button;
    public Button acidActive;
    public bool allDestructive;
    public float destructiveTimer;
    public int duration = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        acidActive.enabled = true;
        if (PlayerPrefs.GetInt("AcidBought") == 0)
        {
            button.SetActive(false);
        }
    }

    void Update()
    {
        if (allDestructive)
        {
            destructiveTimer += Time.deltaTime;
            Mathf.RoundToInt(destructiveTimer);
            if (duration - destructiveTimer < 0)
            {
                allDestructive = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AcidPU")
        {
            allDestructive = false;
            destructiveTimer = 0;
            button.SetActive(true);
        }
    }

    public void ButtonActivate()
    {
        allDestructive = true;
        acidActive.enabled = false;
        button.SetActive(false);
        PlayerPrefs.SetInt("AcidBought", 0);
    }
}
