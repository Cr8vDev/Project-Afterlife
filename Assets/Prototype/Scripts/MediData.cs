using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediData : MonoBehaviour
{
    [SerializeField]
    private int heal;

    public int GetMedikit()
    {
        Destroy(gameObject);

        return heal;
    }
}
