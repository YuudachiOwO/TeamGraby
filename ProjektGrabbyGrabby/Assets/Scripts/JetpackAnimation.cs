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



    public void Awake()
    {
        jetpack = GameObject.FindGameObjectWithTag("Jetpack");
        jetpackAnim = jetpack.GetComponent<Animator>();
        boost.jetpackBurning = false;
    }

    void Start()
    {
        jetpack.SetActive(false);
    }

    void Update()
    {
        if (boost.enabled)
        {
            jetpack.SetActive(true);
            jetpackAnim.SetBool("isActive", true);

            if (jetpackPowerUP.timePassed >= jetpackPowerUP.duration)
            {
                boost.jetpackBurning = false;
                jetpack.SetActive(false);
            }

            if (boost.jetpackBurning)
            {
                jetpackPowerUP.timePassed += Time.deltaTime;
                Mathf.RoundToInt(jetpackPowerUP.timePassed);
                jetpackPowerUP.durationCount = jetpackPowerUP.duration - jetpackPowerUP.timePassed;
            }
        }
        else
        {
            jetpack.SetActive(false);
        }
    }
}
