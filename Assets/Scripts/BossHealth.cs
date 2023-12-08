using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int _bossHealth = 1000;

    BossController bossMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerShot")
        {
            _bossHealth -= 10;
            Destroy(other.gameObject);

            bossMove = GetComponentInParent<BossController>();

            if (_bossHealth <= 0)
                bossMove.BossDeath();
        }
    }
}
