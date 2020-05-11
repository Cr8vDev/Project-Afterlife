using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrigger : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag[0] == '0')
        {
            other.GetComponent<Health>().DealDamage(damage);

            Destroy(transform.parent.gameObject);
        }
    }
}
