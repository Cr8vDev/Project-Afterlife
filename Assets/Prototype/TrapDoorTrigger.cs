using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject stageTwoHordeActivator;
    [SerializeField]
    private GameObject trapDoor;

    public void EnableFinalStage()
    {
        trapDoor.SetActive(true);
        stageTwoHordeActivator.SetActive(false);
        Destroy(gameObject);
    }
}
