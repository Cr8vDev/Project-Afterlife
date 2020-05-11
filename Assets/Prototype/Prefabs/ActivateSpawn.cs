using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawn : MonoBehaviour
{
    [SerializeField]
    private HordeSpawn hordeSpawn;
    [SerializeField]
    private GameObject bossSpawn;
    [SerializeField]
    private Playlist playlist;

    [SerializeField]
    private int initialSpawnNumber;

    [SerializeField]
    private int spawnIncrement;

    [SerializeField]
    private int waves;

    [SerializeField]
    private float minTime;
    [SerializeField]
    private float maxTime;

    private void OnDisable()
    {
        hordeSpawn.gameObject.SetActive(true);
        hordeSpawn.SetData(initialSpawnNumber, spawnIncrement, waves, minTime, maxTime);

        if (bossSpawn != null)
        {
            bossSpawn.SetActive(true);
        }

        playlist.GetComponent<AudioSource>().Stop();
        playlist.musicType = MusicType.Horde;
    }
}
