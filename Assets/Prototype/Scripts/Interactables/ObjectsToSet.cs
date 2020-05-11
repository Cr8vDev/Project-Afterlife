using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectToTrigger
{
    public bool triggerOnDisable = false;
    public GameObject objectsToEnable;
}

public class ObjectsToSet : MonoBehaviour
{
    public ObjectToTrigger objectToTrigger;
    public bool shouldObjectBeDisabled;

    private void OnDisable()
    {
        if(objectToTrigger.triggerOnDisable)
        {
            objectToTrigger.objectsToEnable.SetActive(true);
        }
    }
}
