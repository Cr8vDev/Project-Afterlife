using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HordeAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 targetPosition;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    float inputDelay;
    float pathDelay;

    NavMeshHit hit;
    NavMeshPath path;

    NavMeshAgent agent;
    NavMeshObstacle obstacle;

    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private Health zombieHealth;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float damageDelay;
    private float setDamageDelay = 0;

    public void InitializeOnCreate(GameManager sGameManager, Transform sTarget, Health sHealth, HordeSpawn hordeSpawn, BossSpawn bossSpawn)
    {
        gameManager = sGameManager;
        target = sTarget;
        playerHealth = sHealth;

        zombieHealth.bossSpawn = bossSpawn;
        zombieHealth.hordeSpawn = hordeSpawn;
    }

    public void InitializeOnCreate(GameManager sGameManager, Transform sTarget, Health sHealth, HordeSpawn hordeSpawn)
    {
        gameManager = sGameManager;
        target = sTarget;
        playerHealth = sHealth;

        zombieHealth.hordeSpawn = hordeSpawn;
    }

    private void Start()
    {
        path = new NavMeshPath();

        pathDelay = inputDelay;

        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
    }

    void Update()
    {
        if (gameManager.gameState == 0)
        {
            if (target != null)
            {
                if (Time.realtimeSinceStartup > pathDelay)
                {
                    NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

                    pathDelay = Time.realtimeSinceStartup + inputDelay;
                }

                if (Vector3.Distance(transform.position, target.position) > 0.5f)
                {

                    if (agent.isActiveAndEnabled)
                    {
                        if (path.status == NavMeshPathStatus.PathPartial)
                        {
                            targetPosition = path.corners[path.corners.Length - 1];
                        }
                        else
                        {
                            targetPosition = target.position;
                        }

                        agent.destination = targetPosition;
                    }
                    else if (obstacle.isActiveAndEnabled)
                    {
                        obstacle.enabled = false;
                    }
                    else if (!agent.isActiveAndEnabled)
                    {
                        agent.enabled = true;
                    }
                }
                else
                {
                    agent.enabled = false;
                    obstacle.enabled = true;

                    if (Time.time > setDamageDelay)
                    {
                        playerHealth.DealDamage(damage);
                        setDamageDelay = Time.time + damageDelay;
                    }
                }
            }
        }
        else
        {
            agent.enabled = false;
        }
    }
}
