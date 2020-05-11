using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField]
    private ObjectsToSet activator;

    public void DisableObject()
    {
        transform.parent.gameObject.SetActive(false);

        if(activator.shouldObjectBeDisabled)
        {
            activator.gameObject.SetActive(false);
        }
    }
}
