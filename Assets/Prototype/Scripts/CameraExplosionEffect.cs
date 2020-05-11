using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraExplosionEffect : MonoBehaviour
{
    private void Awake()
    {
        StaticDataContainer.cameraExplosionEffect = this;
    }

    public void ShakeCamera()
    {
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
    }
}
