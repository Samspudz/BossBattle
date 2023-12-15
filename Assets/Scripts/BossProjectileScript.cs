using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossProjectileScript : MonoBehaviour
{
    BossController bossCTRL;
    CameraShakeScript camShake;

    public Transform shockSpawn, rockSpawn, playerTarget;

    public Rigidbody _shockwave;
    public GameObject _rockProjectile;

    void Start()
    {
        bossCTRL = GetComponent<BossController>();
        playerTarget = GameObject.FindGameObjectWithTag("RockTarget").transform;
        camShake = FindObjectOfType<CameraShakeScript>();
    }

    public void ShockProjectile()
    {
        camShake.ShakeY();
        Rigidbody _shock;
        _shock = Instantiate(_shockwave, shockSpawn.position, shockSpawn.rotation) as Rigidbody;
        _shock.AddForce(shockSpawn.forward * 1000f, ForceMode.Acceleration);
    }

    public void RockThrow()
    {
        GameObject _flameRock;
        _flameRock = Instantiate(_rockProjectile, rockSpawn.position, rockSpawn.rotation);
        _flameRock.transform.DOJump(playerTarget.position, 5, 1, 1.5f).SetEase(Ease.Linear);

        _flameRock = Instantiate(_rockProjectile, rockSpawn.position, rockSpawn.rotation);
        _flameRock.transform.DOJump(new Vector3(playerTarget.position.x - 3, playerTarget.position.y, playerTarget.position.z), 5, 1, 1.5f).SetEase(Ease.Linear);

        _flameRock = Instantiate(_rockProjectile, rockSpawn.position, rockSpawn.rotation);
        _flameRock.transform.DOJump(new Vector3(playerTarget.position.x + 3, playerTarget.position.y, playerTarget.position.z), 5, 1, 1.5f).SetEase(Ease.Linear);
    }
}
