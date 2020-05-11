using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType
{
    Normal,
    Horde
}

public class Playlist : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> playListNormal;
    [SerializeField]
    private List<AudioClip> playListHorde;
    [SerializeField]
    private AudioSource audioSource;

    public MusicType musicType;

    private int current = 0;

    [HideInInspector]
    public bool startMusic = false;

    private void Update()
    {
        if (audioSource.isActiveAndEnabled)
        {
            if (musicType == MusicType.Normal)
            {
                if (startMusic)
                {
                    if (!audioSource.isPlaying)
                    {
                        if (current < playListNormal.Count)
                        {
                            audioSource.clip = playListNormal[current];

                            audioSource.Play();

                            current++;
                        }
                        else
                        {
                            current = 0;
                        }
                    }
                }
            }
            else if (musicType == MusicType.Horde)
            {
                if (startMusic)
                {
                    if (!audioSource.isPlaying)
                    {
                        if (current < playListHorde.Count)
                        {
                            audioSource.clip = playListHorde[current];

                            audioSource.Play();

                            current++;
                        }
                        else
                        {
                            current = 0;
                        }
                    }
                }
            }
        }
    }
}
