using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int knightHealth = 5;
    PlayerMovement knightCTRL;

    void Start()
    {
        knightCTRL = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShot" || other.gameObject.tag == "EnemyBoss")
        {
            knightHealth--;
            if (knightHealth <= 0)
                knightCTRL.PlayerDeath();
        }
    }
}
