using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUtilities : MonoBehaviour
{
    public int coin;
    public int shieldLevel;
    public float shieldTimer;
    public int shieldPrice;
    public Text shieldStats;
    public Text totalCoins;
    public Text shieldTextPrice;

    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("totalCoin");
        shieldLevel = PlayerPrefs.GetInt("shieldLevel");
        shieldTimer = 5f + (0.5f * shieldLevel);
        shieldPrice = shieldLevel * 5;
    }

    // Update is called once per frame
    void Update()
    {
        totalCoins.text = "Coins : " + coin;
        shieldStats.text = "Current Stats :\n" + shieldTimer + " seconds\n After Upgrade :\n" + (shieldTimer + 0.5f) + " seconds";
        shieldTextPrice.text = "Upgrade for : " + shieldPrice;
        if (shieldPrice > coin)
            shieldTextPrice.color = new Color(183, 0, 0);
    }

    public void UpgradeShield()
    {
        if (shieldPrice < coin)
        {
            coin -= shieldLevel * 5;
            shieldLevel += 1;
            shieldTimer += 0.5f;
            shieldPrice = shieldLevel * 5;
            PlayerPrefs.SetInt("totalCoin", coin);
            PlayerPrefs.SetInt("shieldLevel", shieldLevel);
        }
    }
}
