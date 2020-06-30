using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardWallBreak : MonoBehaviour
{
    public AcidTrip acidTrip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (acidTrip.allDestructive && other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
