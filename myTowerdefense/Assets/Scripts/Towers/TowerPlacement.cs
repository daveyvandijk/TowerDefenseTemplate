using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private TowerSlot[] towerSlots;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();          
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                
                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.GetComponent<TowerSlot>());
                if (towerSlotIndex != -1)
                {
                    if (towerSlots[towerSlotIndex].tower != null)
                    {
                        return;
                    }

                    if (playerStats.GetCoinCount() >= 5)
                    {
                        PlaceTower(towerSlotIndex);

                        playerStats.DecreaseCoins(5);
                    }
                    

                    
                }
            }
        }
    }

    void PlaceTower(int towerSlotIndex)
    {
        Tower tower = Instantiate(towerPrefab);
        towerSlots[towerSlotIndex].tower = tower;
        tower.transform.position = towerSlots[towerSlotIndex].transform.position;
    }
}
