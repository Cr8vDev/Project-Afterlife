using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None,
    Chainsaw,
    Shotgun,
    Minigun,
    RocketLauncher
}

[System.Serializable]
public class Weapon
{
    public Sprite sprite;
    public Transform weapon;
    public int ammo;
    public WeaponType weaponType;
    public AudioClip weaponEquipSound;
}

public class WeaponData : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    public TriggerType triggerType;

    public Weapon GetWeapon()
    {
        Destroy(transform.parent.gameObject);

        return weapon;
    }
}
