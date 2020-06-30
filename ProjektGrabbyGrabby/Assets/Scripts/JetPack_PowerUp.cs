using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;

public class JetPack_PowerUp : MonoBehaviour
{
    public GameObject player;
    public Jetpack_Boost boost;
    public float duration = 5f;
    public bool isNumbering;
    public float timePassed;
    //public Text durationText;
    public float durationCount;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boost = player.GetComponent<Jetpack_Boost>();
        boost.enabled = false;
        boost.jetpackBurning = false;
       // durationText.enabled = false;
    }
    void Update()
    {


        if (boost.enabled)
        {
           // durationText.enabled = true;
          //  durationText.text = "Jetpack Duration: " + durationCount;

            if (/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began*/ Input.GetMouseButtonDown(0))
            {
                boost.jetpackBurning = true;
            }

            if (/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended*/ Input.GetMouseButtonUp(0))
            {
                boost.jetpackBurning = false;
            }
            if (timePassed >= duration)
            {
                boost.jetpackBurning = false;
                boost.enabled = false;
            }
            if (boost.jetpackBurning)
            {
                timePassed += Time.deltaTime;
                Mathf.RoundToInt(timePassed);
                durationCount = duration - timePassed;
            }

        }
        else
        {            
          //  durationText.enabled = false;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            timePassed = 0;
            boost.enabled = true;
        }
    }
}
