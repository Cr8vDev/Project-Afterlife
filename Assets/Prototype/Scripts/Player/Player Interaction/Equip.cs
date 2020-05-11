using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Equip : MonoBehaviour
{
    [HideInInspector]
    public bool isEquipped = false;

    [SerializeField]
    private Transform weaponSpawn;

    private Weapon currentWeapon;

    [SerializeField]
    private TextMeshProUGUI ammoCounter;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private MuzzleAnimation muzzleAnimation;



    public void EquipWeapon(Weapon weapon)
    {
        if(weaponSpawn.childCount > 1)
        {
            Destroy(weaponSpawn.GetChild(1).gameObject);
        }

        var weaponInstance = Instantiate(weapon.weapon, weaponSpawn.position, weaponSpawn.rotation, weaponSpawn) as Transform;

        isEquipped = true;
        currentWeapon = weapon;

        if (weaponInstance.GetComponent<Shotgun>() != null)
        {
            ammoCounter.text = "Ammo: " + currentWeapon.ammo;
            weaponInstance.GetComponent<Shotgun>().SetEquip(this, ammoCounter, gameManager, muzzleAnimation);
        }
        else if (weaponInstance.GetComponent<Minigun>() != null)
        {
            ammoCounter.text = "Ammo: " + currentWeapon.ammo;
            weaponInstance.GetComponent<Minigun>().SetEquip(this, ammoCounter, gameManager, muzzleAnimation);
        }
        else if (weaponInstance.GetComponent<RocketLauncher>() != null)
        {
            ammoCounter.text = "Ammo: " + currentWeapon.ammo;
            weaponInstance.GetComponent<RocketLauncher>().SetEquip(this, ammoCounter, gameManager, muzzleAnimation);
        }
        else if (weaponInstance.GetComponent<Chainsaw>() != null)
        {
            ammoCounter.text = "Ammo: Unlimited";
            weaponInstance.GetComponent<Chainsaw>().SetEquip(this, ammoCounter, gameManager, muzzleAnimation);
        }

        audioSource.clip = weapon.weaponEquipSound;
        audioSource.Play();
    }

    public Weapon GetWeapon()
    {
        return currentWeapon;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(inventory.weapons[0].sprite != null)
            {
                EquipWeapon(inventory.weapons[0]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventory.weapons[1].sprite != null)
            {
                EquipWeapon(inventory.weapons[1]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inventory.weapons[2].sprite != null)
            {
                EquipWeapon(inventory.weapons[2]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (inventory.weapons[3].sprite != null)
            {
                EquipWeapon(inventory.weapons[3]);
            }
        }
    }
}
