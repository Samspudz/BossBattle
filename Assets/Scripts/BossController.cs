using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class BossController : MonoBehaviour
{
    BossProjectileScript bossProjectiles;

    Rigidbody bossRB;
    Animator bossAnim;

    public Transform leftside, rightside;
    Collider groundCol;

    [SerializeField] private bool bossDead;
    [SerializeField] private bool facingLeft;

    void Start()
    {
        bossRB = GetComponent<Rigidbody>();
        bossAnim = GetComponentInChildren<Animator>();
        bossProjectiles = GetComponentInChildren<BossProjectileScript>();
        StartCoroutine(ShockAttack());
        facingLeft = true;
        groundCol = GetComponent<Collider>();
    }

    IEnumerator ShockAttack()
    {
        yield return new WaitForSeconds(1);

        if (!bossDead)
        {
            int shockNumber = 3;
            while (shockNumber >= 0 && !bossDead)
            {
                bossAnim.SetTrigger("Shockwave");
                shockNumber--;
                yield return new WaitForSeconds(1.25f);
            }
            yield return new WaitForSeconds(2);

            StartCoroutine(RockAttack());
        }
    }

    IEnumerator RockAttack()
    {
        yield return new WaitForSeconds(1);

        if (!bossDead)
        {
            bossRB.AddForce(Vector3.up * 15, ForceMode.Impulse);
            yield return new WaitForSeconds(1);
            bossProjectiles.RockThrow();

            yield return new WaitForSeconds(3);

            StartCoroutine(ChargeAttack());
        }
    }

    IEnumerator ChargeAttack()
    {
        yield return new WaitForSeconds(1);

        if (!bossDead)
        {
            bossAnim.SetTrigger("Charge");
            //groundCol.enabled = false;
            bossRB.useGravity = false;
            yield return new WaitForSeconds(1.5f);

            if (facingLeft)
            {
                transform.DOMove(leftside.position, 1).SetEase(Ease.InSine).OnComplete(TurnBoss);
            }
            else
            {
                transform.DOMove(rightside.position, 1).SetEase(Ease.InSine).OnComplete(TurnBoss);
            }
        }
    }

    void TurnBoss()
    {
        if (!bossDead)
        {
            if (facingLeft)
            {
                transform.DORotate(Vector3.up * 180, 0.2f, RotateMode.Fast);
            }
            else
            {
                transform.DORotate(Vector3.up * 0, 0.2f, RotateMode.Fast);
            }

            //groundCol.enabled = true;
            bossRB.useGravity = true;
            facingLeft = !facingLeft;
            bossAnim.SetTrigger("Standing");
        }
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
