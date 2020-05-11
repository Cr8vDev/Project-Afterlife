using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Needs to be on player object.
//Triggers when player enters interactable trigger.
//PlayerInput.cs receives data

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public Speech speech;
    [HideInInspector]
    public TriggerSound triggerSound;
    [HideInInspector]
    public WeaponData weaponData;

    [SerializeField]
    private SpeechUI speechUI;

    [SerializeField]
    private GameObject interactUI;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private Transform inventoryUI;

    [SerializeField]
    private Equip equip;

    private ObjectsToSet objectToSet;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Health playerHealth;

    [SerializeField]
    private TextMeshProUGUI ammoUI;

    [SerializeField]
    private Message setMessage;

    [SerializeField]
    private float damageAreaDelay;
    private float setDamageAreaDelay = 0f;

    [SerializeField]
    private float damageIndicatorDelay;
    private float setIndicatorDelay = 0f;

    [SerializeField]
    private Image damageIndicator;

    [SerializeField]
    private TrapDoorTrigger trapDoorTrigger;


    public void ResetData()
    {
        speech = null;
        triggerSound = null;
        weaponData = null;
        objectToSet = null;
        interactUI.SetActive(false);
    }



    private void SetObjects(Collider collision)
    {
        if (collision.GetComponent<ObjectsToSet>() != null)
        {
            objectToSet = collision.GetComponent<ObjectsToSet>();
        }
    }



    public void SpeechTrigger()
    {
        speechUI.SetMessage(speech.message);

        if (objectToSet != null)
        {
            speechUI.ObjectsToSet(objectToSet);
        }
    }



    public void AudioTrigger()
    {
        triggerSound.PlayerAudio();

        if (objectToSet != null)
        {
            if (objectToSet.objectToTrigger.objectsToEnable != null)
            {
                objectToSet.objectToTrigger.objectsToEnable.SetActive(true);
            }

            if (objectToSet.shouldObjectBeDisabled)
            {
                triggerSound.gameObject.SetActive(false);
            }
        }
    }



    public void PickUpWeapon()
    {
        for (int i = 0; i < inventory.weapons.Count; ++i)
        {
            if (inventory.weapons[i].sprite == null)
            {
                inventoryUI.GetChild(i).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                var getWeapon = weaponData.GetWeapon();
                inventoryUI.GetChild(i).GetComponent<Image>().sprite = getWeapon.sprite;
                inventory.weapons[i] = getWeapon;

                if (!equip.isEquipped)
                {
                    equip.EquipWeapon(inventory.weapons[i]);
                }
                else
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                }

                break;
            }
        }

        setMessage.SetMessage("You have picked up weapon");

        ResetData();
    }



    private void Heal(MediData mediData)
    {
        if (playerHealth.GetHealth() < 100)
        {
            playerHealth.Heal(mediData.GetMedikit());
            setMessage.SetMessage("You have picked up health");
        }
        else
        {
            setMessage.SetMessage("You have full health");
        }
    }


    private void Ammo(Ammo ammoValue)
    {
        for(int i = 0; i < inventory.weapons.Count; ++i)
        {
            if(inventory.weapons[i].weaponType == ammoValue.GetAmmoType())
            {
                var getAmmo = ammoValue.GetAmmo();

                inventory.weapons[i].ammo += getAmmo;

                ammoUI.text = "Ammo: " + inventory.weapons[i].ammo;

                audioSource.clip = ammoValue.GetAudioClip();

                audioSource.Play();

                setMessage.SetMessage("Picked Up Ammo");

                return;
            }
        }

        setMessage.SetMessage("You do not have this weapon");
    }



    private void OnTriggerEnter(Collider collision)
    {
        //Speech trigger
        if (collision.tag[0] == '1')
        {
            speech = collision.GetComponent<Speech>();

            SetObjects(collision);

            if (speech.speechType == TriggerType.AutoTrigger)
            {
                SpeechTrigger();
            }
            else
            {
                interactUI.SetActive(true);
            }
        }
        //Tutorial trigger
        else if (collision.tag[0] == '2')
        {
            var tutorial = collision.GetComponent<Tutorial>();

            tutorial.tutorial.SetActive(true);
        }
        //Audio trigger
        else if (collision.tag[0] == '3')
        {
            triggerSound = collision.GetComponent<TriggerSound>();

            SetObjects(collision);

            if (triggerSound.triggerType == TriggerType.AutoTrigger)
            {
                AudioTrigger();
            }
            else
            {
                interactUI.SetActive(true);
            }
        }
        //Pickup item
        else if (collision.tag[0] == '4')
        {
            weaponData = collision.GetComponent<WeaponData>();

            if (weaponData.triggerType == TriggerType.AutoTrigger)
            {
                PickUpWeapon();
            }
            else
            {
                interactUI.SetActive(true);
            }
        }
        //Pickup Ammo
        else if (collision.tag[0] == '6')
        {
            Ammo(collision.GetComponent<Ammo>());
        }
        //Pickup Medikit
        else if (collision.tag[0] == '8')
        {
            Heal(collision.GetComponent<MediData>());
        }
        else if(collision.tag[0] == 'f')
        {
            trapDoorTrigger.EnableFinalStage();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Damage areas
        if (other.tag[0] == '9')
        {
            if (Time.time > setDamageAreaDelay)
            {
                playerHealth.DealDamage(2);

                setDamageAreaDelay = Time.time + damageAreaDelay;

                damageIndicator.color = new Color(1f, 0f, 0f, 1f);

                setIndicatorDelay = Time.time + damageIndicatorDelay;
            }

            if(Time.time > setIndicatorDelay)
            {
                damageIndicator.color = new Color(1f, 0f, 0f, 0f);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        ResetData();
        damageIndicator.color = new Color(1f, 0f, 0f, 0f);
    }
}
