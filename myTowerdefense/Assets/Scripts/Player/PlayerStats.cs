using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerStats : MonoBehaviour
{

    public Text HPText;
    public Text CoinsText;

    public static int Health;
    public static int Coin;
    public int MaxHealth;
    public int MaxCoin;

    

    public void Start()
    {
        Health = MaxHealth;
        Coin = MaxCoin;
        WaypointFollower.AddOnWaypointEndTriggerListener(TakeDamage);
        //newEnemyHealth.AddonGetCoinsTriggerListener(GetCoins);
    }

    
    void Update()
    {
       if (Health < 1 )
        {
            Debug.Log("DEAD");
        }
    }

    public void TakeDamage()
    {
        Debug.Log("take damage");
        Health--;
        UpdateHealthText();  
    }

    //public void GetCoins()
    //{
    //    Debug.Log("get coins");
    //    Coin++;
    //    UpdateCoinText();
    //}

    public void UpdateHealthText()
    {
        HPText.text = "Health:" + Health.ToString();
    }

    public void UpdateCoinText()
    {
        CoinsText.text = "Coins:" + Coin.ToString();
    }
}