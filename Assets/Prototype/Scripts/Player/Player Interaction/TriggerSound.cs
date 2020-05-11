using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField]
    public TriggerType triggerType;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    public void PlayerAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
