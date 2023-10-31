using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerStats : MonoBehaviour
{
    public GameObject DeathScreen;

    public Text HPText;
    public Text CoinsText;

    public static int Health;
    public static int Coin;
    public int MaxHealth;
    public int MaxCoin;

    

    public void Start()
    {   
        DeathScreen.SetActive(false);
        Health = MaxHealth;
        Coin = MaxCoin;
        WaypointFollower.AddOnWaypointEndTriggerListener(TakeDamage);
        newEnemyHealth.AddonGetCoinsTriggerListener(GetCoins);
    }

    
    void Update()
    {
       if (Health < 1 )
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;   
        }
        
    }

    public void TakeDamage()
    {
        Health--;
        UpdateHealthText();  
    }

    public void GetCoins()
    {
        Coin++;
        UpdateCoinText();
    }

    public void DecreaseCoins(int amount)
    {
        Coin -= amount;
        UpdateCoinText();
    }

    public int GetCoinCount()
    {
        return Coin;
    }

    public void UpdateHealthText()
    {
        HPText.text = "Health:" + Health.ToString();
    }

   public void UpdateCoinText()
   {
        CoinsText.text = "Coins:" + Coin.ToString();
   }
}