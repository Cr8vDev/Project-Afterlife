using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeRotationOffset : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
    }
}
