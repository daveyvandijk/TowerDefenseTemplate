using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class health : MonoBehaviour
{
    public TMP_Text HealthText;
    public TMP_Text CoinText;

    public int Health;
    public int Coin;
    public int Maxhealth;


    // Update is called once per frame
    void Update()
    {
       if (Health < Maxhealth)
        {
            Debug.Log("DEADTH SCREEN");
        }


        
    }
}