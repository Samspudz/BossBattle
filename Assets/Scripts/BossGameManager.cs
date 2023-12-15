using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameManager : MonoBehaviour
{

    [SerializeField] BossHealth bossHealth;
    [SerializeField] PlayerHealth playerHealth;

    public Image bossLifeBar;

    //Knight heart images
    public int playerHearts = 5;
    public int numberOfHearts = 5;

    public Image[] _hearts;

    public Sprite heartFull;
    public Sprite heartEmpty;

    private void Awake()
    {
        bossHealth = FindObjectOfType<BossHealth>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        bossLifeBar.fillAmount = bossHealth._bossHealth * 0.001f;

        playerHearts = playerHealth.knightHealth;
         
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < numberOfHearts)
                _hearts[i].enabled = true;
            else
                _hearts[i].enabled = false;

            if (i < playerHearts)
                _hearts[i].sprite = heartFull;
            else
                _hearts[i].sprite = heartEmpty;
        }
    }
}
