using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestroyAtEndOfAudio : MonoBehaviour
{
    [HideInInspector]
    public bool playAudio = false;
    [SerializeField]
    private AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if(playAudio)
        {
            if(!audioSource.isPlaying)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
