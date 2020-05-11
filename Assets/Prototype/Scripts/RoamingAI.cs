using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamingAI : MonoBehaviour
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
    private int damage;
    [SerializeField]
    private float damageDelay;
    private float setDamageDelay = 0;

    private Vector3 randomLocation;
    private bool randomLocationSet = false;

    private bool triggerChase = false;

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
            agent.enabled = true;

            if (target != null)
            {
                if (Time.realtimeSinceStartup > pathDelay)
                {
                    NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

                    pathDelay = Time.realtimeSinceStartup + inputDelay;
                }

                if (triggerChase)
                {
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

                            agent.speed = 0.5f;

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
                        if (agent.isActiveAndEnabled)
                        {
                            agent.enabled = false;
                        }
                        else if (!obstacle.isActiveAndEnabled)
                        {
                            obstacle.enabled = true;
                        }

                        if (Time.time > setDamageDelay)
                        {
                            playerHealth.DealDamage(damage);
                            setDamageDelay = Time.time + damageDelay;
                        }
                    }
                }
                else
                {
                    if (Vector3.Distance(transform.position, target.position) < 2.0f)
                    {
                        triggerChase = true;
                    }
                    else
                    {
                        if (!randomLocationSet)
                        {
                            var randomPoints = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

                            randomLocation = transform.position + randomPoints;

                            randomLocationSet = true;

                            agent.speed = 0.1f;
                        }
                        else
                        {
                            agent.destination = randomLocation;

                            if (Vector3.Distance(transform.position, randomLocation) < 0.1f)
                            {
                                randomLocationSet = false;
                            }
                        }
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
