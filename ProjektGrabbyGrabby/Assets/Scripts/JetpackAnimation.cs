using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackAnimation : MonoBehaviour
{
    public GameObject jetpack;
    public Animator jetpackAnim;
    public GameObject player;
    public Jetpack_Boost boost;
    public JetPack_PowerUp jetpackPowerUP;
    public bool isNumbering;



    public void Awake()
    {
     jetpack = GameObject.FindGameObjectWithTag("Jetpack");
     jetpackAnim = jetpack.GetComponent<Animator>();
     jetpackAnim.enabled = false;
    }

    void Start()
    {
        jetpack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boost.enabled)
        {
            jetpack.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                jetpackAnim.enabled = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                jetpackAnim.enabled = false;
            }

            if (jetpackPowerUP.timePassed >= jetpackPowerUP.duration)
            {
                jetpack.SetActive(false);
            }

            if (boost.jetpackBurning)
            {
                jetpackPowerUP.timePassed += Time.deltaTime;
                Mathf.RoundToInt(jetpackPowerUP.timePassed);
                jetpackPowerUP.durationCount = jetpackPowerUP.duration - jetpackPowerUP.timePassed;
            }
        }
    }
}
