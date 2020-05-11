using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private int damage;
    [SerializeField]
    private RocketDestroyAtEndOfAudio destoryParentAtEndOfAudio;

    private void OnTriggerEnter(Collider collision)
    {
        //Deal damage
        if (collision.tag[0] == '7')
        {
            collision.GetComponentInChildren<ParticleSystem>().Play();

            if (audioSource != null)
            {
                audioSource.Play();
            }

            collision.GetComponent<Health>().DealDamage(damage);

            Destroy(gameObject);

            destoryParentAtEndOfAudio.playAudio = true;
        }
    }
}
