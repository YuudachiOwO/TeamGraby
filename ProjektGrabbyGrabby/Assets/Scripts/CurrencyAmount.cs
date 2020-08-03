using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyAmount : MonoBehaviour
{

    public int coins;
    public int newCoins;
    public Text coinText;
    public Button jetpackShopButton;
    public Button acidShopButton;
    public Button jumpShopButton;
    public GameObject shopPanel;

    void Update()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = "Graby-Coins: " + coins;
    }

    public void JetpackBuy()
    {
        if (coins >= 10 && PlayerPrefs.GetInt("JetpackBought") == 0)
        {
            newCoins = PlayerPrefs.GetInt("Coins") - 10;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("JetpackBought", 1);
        }
    }

    public void AcidBuy()
    {
        if (coins >= 10 && PlayerPrefs.GetInt("AcidBought") == 0)
        {
            newCoins = PlayerPrefs.GetInt("Coins") - 10;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("AcidBought", 1);
        }
    }
    public void JumpBuy()
    {
        if (coins >= 10 && PlayerPrefs.GetInt("JumpBought") == 0)
        {
            newCoins = PlayerPrefs.GetInt("Coins") - 10;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("JumpBought", 1);
        }
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

}
