using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShakeScript : MonoBehaviour
{
    public void ShakeX()
    {
        transform.DOShakePosition(0.5f, new Vector3(0.5f, 0, 0), 20);
    }

    public void ShakeY()
    {
        transform.DOShakePosition(0.5f, new Vector3(0, 0.5f, 0), 20);
    }
}
