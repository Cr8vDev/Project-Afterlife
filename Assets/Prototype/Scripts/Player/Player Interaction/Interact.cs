using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private SpeechUI speechUI;

    [SerializeField]
    private Interactable interactable;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !speechUI.gameObject.activeInHierarchy)
        {
            if (interactable.speech != null)
            {
                if (interactable.speech.speechType == TriggerType.InputTrigger)
                {
                    interactable.SpeechTrigger();
                }
            }
            else if (interactable.triggerSound != null)
            {
                if (interactable.triggerSound.triggerType == TriggerType.InputTrigger)
                {
                    interactable.AudioTrigger();
                }
            }
            else if (interactable.weaponData != null)
            {
                if (interactable.weaponData.triggerType == TriggerType.InputTrigger)
                {
                    interactable.PickUpWeapon();
                }
            }
        }
    }
}
