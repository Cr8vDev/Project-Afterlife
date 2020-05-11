using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [HideInInspector]
    public int zombiesAlreadyKilled = 0;
    [SerializeField]
    private Transform boss;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Health playerHealth;

    public int totalBosses = 0;

    private void Update()
    {
        if (zombiesAlreadyKilled > 50)
        {
            var bossSpawn = Instantiate(boss, transform.position, Quaternion.identity) as Transform;

            bossSpawn.GetComponentInChildren<BossAI>().InitializeOnCreate(player, gameManager, playerHealth, this);

            zombiesAlreadyKilled = 0;

            totalBosses++;
        }
    }
}
