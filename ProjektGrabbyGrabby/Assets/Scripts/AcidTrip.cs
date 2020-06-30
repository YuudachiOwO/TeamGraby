using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTrip : MonoBehaviour
{

    public bool allDestructive;
    public GameObject player;
    public float destructiveTimer;
    public int duration = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (allDestructive)
        {
            destructiveTimer += Time.deltaTime;
            Mathf.RoundToInt(destructiveTimer);
            if (duration-destructiveTimer < 0)
            {
                allDestructive = false;
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            allDestructive = true;
        }
    }
}
