using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidTrip : MonoBehaviour
{

    public bool allDestructive;
    public GameObject player;
    public float destructiveTimer;
    public int duration = 5;
    public Button acidActive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        acidActive.enabled = false;
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
            destructiveTimer = 0;
            Debug.Log("Hit");
            acidActive.enabled = true;
        }
    }

    public void ButtonActivate()
    {
        allDestructive = true;
        acidActive.enabled = false;
    }
}
