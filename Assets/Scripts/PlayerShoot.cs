using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody _sword;
    public Transform weaponSpawn;
    public float projectileSpeed = 1000f;

    public void PlayerShot()
    {
        Rigidbody rb;
        rb = Instantiate(_sword, weaponSpawn.position, weaponSpawn.rotation) as Rigidbody;
        rb.AddForce(weaponSpawn.right * projectileSpeed);
    }
}
