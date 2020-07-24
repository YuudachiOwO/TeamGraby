using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartPadAnim : MonoBehaviour
{
    public GameObject fartPad;
    public Animator fartAnim;

    void Start()
    {
        fartPad = this.gameObject;
        fartAnim = this.gameObject.GetComponent<Animator>();
        fartAnim.SetBool("Bounced", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!this.gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            fartAnim.SetBool("Bounced", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fartAnim.SetBool("Bounced", true);
        }
    }
}
