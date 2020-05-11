using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private RaycastHit hit;

    [SerializeField]
    private float minDelay;
    [SerializeField]
    private float maxDelay;
    private float setDelay = 0f;

    [SerializeField]
    private Transform fireball;

    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private NavMeshObstacle obstacle;

    [SerializeField]
    private Transform fireballSpawner;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private LayerMask layers;

    [SerializeField]
    private Health playerHealth;

    private float randomTime;

    [SerializeField]
    private float damageDelay;
    private float setDamageDelay;

    private BossSpawn bossSpawn;

    public void InitializeOnCreate(Transform sTarget, GameManager sGameManager, Health sPlayerHealth, BossSpawn sBossSpawn)
    {
        target = sTarget;
        gameManager = sGameManager;
        playerHealth = sPlayerHealth;

        bossSpawn = sBossSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == 0)
        {
            agent.enabled = true;

            if (target != null)
            {
                agent.SetDestination(target.position);

                fireballSpawner.LookAt(target.position);

                if (Time.time > setDelay)
                {
                    if (Physics.Raycast(transform.position, target.position - transform.position, out hit, Mathf.Infinity, layers))
                    {
                        if (hit.collider.tag[0] == '0')
                        {
                            Instantiate(fireball, fireballSpawner.position, Quaternion.Euler(0.0f, fireballSpawner.eulerAngles.y, 0.0f));
                        }
                    }

                    randomTime = Random.Range(minDelay, maxDelay);

                    setDelay = Time.time + randomTime;
                }

                if (Time.time > setDamageDelay)
                {
                    if (Vector3.Distance(transform.position, target.position) < 0.75f)
                    {
                        playerHealth.DealDamage(20);
                    }

                    setDamageDelay = Time.time + damageDelay;
                }
            }
        }
        else
        {
            agent.enabled = false;
            randomTime = 0;
        }
    }

    private void OnDestroy()
    {
        bossSpawn.totalBosses--;
    }
}
