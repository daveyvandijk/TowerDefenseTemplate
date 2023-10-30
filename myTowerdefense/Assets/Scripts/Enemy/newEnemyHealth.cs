using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemyHealth : MonoBehaviour
{
    [SerializeField] public int Health;
    [SerializeField] private int MaxHealth;

    public static event Action onEnemyDestroy;
    //public static event Action onGetCoins;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            
            if(Health < 0)
            {
                onEnemyDestroy?.Invoke();
                //onGetCoins?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public static void AddonEnemyDestroyTriggerListener(Action listener)
    {
        newEnemyHealth.onEnemyDestroy += listener;
    }

   //public static void AddonGetCoinsTriggerListener(Action listener)
   //{
   //     newEnemyHealth.onGetCoins += listener;
   //}

}
