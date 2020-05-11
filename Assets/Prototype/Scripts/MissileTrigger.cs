using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform explosion;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag[0] == '7')
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
