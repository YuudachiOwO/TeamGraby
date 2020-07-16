using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Big_Pufferfish : MonoBehaviour
{
    public GameObject bigPuff;
    public Animator bigPuffAnim;
    void Start()
    {
        bigPuff = this.gameObject;
        bigPuffAnim = bigPuff.GetComponent<Animator>();
        bigPuffAnim.SetBool("isExploding", false);
    }

    void Update()
    {
        if (!bigPuff.GetComponent<SpriteRenderer>().isVisible)
        {
            bigPuffAnim.SetBool("isExploding", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bigPuffAnim.SetBool("isExploding", true);
        }
    }
}
