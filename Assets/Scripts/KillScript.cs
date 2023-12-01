using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float killTime = 2.0f;

    void Start()
    {
        Destroy(gameObject, killTime);
    }
}
