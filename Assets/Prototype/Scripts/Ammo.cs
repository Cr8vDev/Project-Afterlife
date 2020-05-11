using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private WeaponType ammoType;
    [SerializeField]
    private int ammo;
    [SerializeField]
    private AudioClip ammoSound;

    public WeaponType GetAmmoType()
    {
        return ammoType;
    }

    public AudioClip GetAudioClip()
    {
        return ammoSound;
    }

    public int GetAmmo()
    {
        Destroy(gameObject);

        return ammo;
    }
}
