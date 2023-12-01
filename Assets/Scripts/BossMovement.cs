using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    Animator bossAnim;
    [SerializeField] private bool bossDead;

    void Start()
    {
        bossAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
    }

    public void BossDeath()
    {
        if (!bossDead)
        {
            bossDead = true;
            bossAnim.SetTrigger("BossDeath");
        }
    }
}
