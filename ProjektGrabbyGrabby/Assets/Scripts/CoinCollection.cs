using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{

    public int coins;
    public int oldCoin;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            oldCoin = PlayerPrefs.GetInt("Coins");
            PlayerPrefs.SetInt("Coins", coins + oldCoin);
            PlayerPrefs.Save();
            Debug.Log(coins);
        }
    }
}
