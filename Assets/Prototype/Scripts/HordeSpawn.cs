using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HordeSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform hordeCollector;

    [SerializeField]
    private bool spawnsContainNestedPoints = false;
    [SerializeField]
    private List<GameObject> levelThreeObjects;
    [SerializeField]
    private List<GameObject> levelFiveObjects;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private List<Transform> zombie;

    [SerializeField]
    private GameObject waveText;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Health playerHealth;

    [SerializeField]
    private BossSpawn bossSpawn;

    private float setDelay;

    [HideInInspector]
    public float minTime;
    [HideInInspector]
    public float maxTime;

    private int maxZombieInScene = 100;

    private int totalWaves;
    public int currentWave = 0;

    private int numberOfZombiesInWave;
    private int incrementSpawnUnits;

    private Transform demon;

    private int h = 0;
    private int i = 0;

    private bool waveComplete = false;

    private float nextWaveDelay = 0;

    private int zombieCounter = 0;

    [SerializeField]
    private GameObject triggerEvent;

    [SerializeField]
    private Playlist playlist;

    private void Start()
    {
        currentWave = 0;
    }

    public void SetData(int initialSpawnNumber, int spawnIncrement, int sWaves, float sMinTime, float sMaxTime)
    {
        numberOfZombiesInWave = initialSpawnNumber;
        minTime = sMinTime;
        maxTime = sMaxTime;
        totalWaves = sWaves;
        incrementSpawnUnits = spawnIncrement;

        nextWaveDelay = Time.time + 3.0f;
    }

    private void SetWaveUI()
    {
        waveText.gameObject.SetActive(true);

        if (currentWave == 0)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave One";
        }
        else if (currentWave == 1)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Two";
        }
        else if (currentWave == 2)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Three";
        }
        else if (currentWave == 3)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Four";
        }
        else if (currentWave == 4)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Five";
        }
        else if (currentWave == 5)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Six";
        }
        else if (currentWave == 6)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Seven";
        }
        else if (currentWave == 7)
        {
            waveText.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Eight";
        }
    }

    private void InstantiateZombie()
    {
        if (!spawnsContainNestedPoints)
        {
            if (zombie.Count > 1)
            {
                if (zombie.Count == 2)
                {
                    var randomZombie = Random.Range(0, 100);

                    if (randomZombie <= 50 && randomZombie > 0)
                    {
                        demon = Instantiate(zombie[0], transform.GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                    else if (randomZombie <= 100 && randomZombie > 50)
                    {
                        demon = Instantiate(zombie[1], transform.GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                }
                else if(zombie.Count == 3)
                {
                    var randomZombie = Random.Range(0, 99);

                    if (randomZombie <= 33 && randomZombie > 0)
                    {
                        demon = Instantiate(zombie[0], transform.GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                    else if (randomZombie <= 66 && randomZombie > 33)
                    {
                        demon = Instantiate(zombie[1], transform.GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                    else if (randomZombie <= 99 && randomZombie > 66)
                    {
                        demon = Instantiate(zombie[2], transform.GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                }
            }
            else
            {
                demon = Instantiate(zombie[0], transform.GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
            }

            if (bossSpawn != null)
            {
                demon.GetComponent<HordeAI>().InitializeOnCreate(gameManager, player, playerHealth, this, bossSpawn);
            }
            else
            {
                demon.GetComponent<HordeAI>().InitializeOnCreate(gameManager, player, playerHealth, this);
            }

            ++i;
            zombieCounter++;
        }
        else
        {
            if (zombie.Count > 1)
            {
                if (zombie.Count == 2)
                {
                    var randomZombie = Random.Range(0, 100);

                    if (randomZombie <= 50 && randomZombie > 0)
                    {
                        demon = Instantiate(zombie[0], transform.GetChild(h).GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                    else if (randomZombie <= 100 && randomZombie > 50)
                    {
                        demon = Instantiate(zombie[1], transform.GetChild(h).GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                }
                else if (zombie.Count == 3)
                {
                    var randomZombie = Random.Range(0, 99);

                    if (randomZombie <= 33 && randomZombie > 0)
                    {
                        demon = Instantiate(zombie[0], transform.GetChild(h).GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                    else if (randomZombie <= 66 && randomZombie > 33)
                    {
                        demon = Instantiate(zombie[1], transform.GetChild(h).GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                    else if (randomZombie <= 99 && randomZombie > 66)
                    {
                        demon = Instantiate(zombie[2], transform.GetChild(h).GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
                    }
                }
            }
            else
            {
                demon = Instantiate(zombie[0], transform.GetChild(h).GetChild(i).position, Quaternion.identity, hordeCollector) as Transform;
            }

            if (bossSpawn != null)
            {
                demon.GetComponent<HordeAI>().InitializeOnCreate(gameManager, player, playerHealth, this, bossSpawn);
            }
            else
            {
                demon.GetComponent<HordeAI>().InitializeOnCreate(gameManager, player, playerHealth, this);
            }

            ++i;
            zombieCounter++;
        }
    }

    private void Update()
    {
        if (currentWave < totalWaves)
        {
            if (zombieCounter >= numberOfZombiesInWave)
            {
                if (hordeCollector.childCount == 0)
                {
                    currentWave++;
                    numberOfZombiesInWave += incrementSpawnUnits;
                    zombieCounter = 0;
                    nextWaveDelay = Time.time + 3.0f;

                    if (spawnsContainNestedPoints)
                    {
                        if (currentWave == 2)
                        {
                            for (int j = 0; j < levelThreeObjects.Count; ++j)
                            {
                                levelThreeObjects[j].SetActive(true);
                            }
                        }
                        else if (currentWave == 4)
                        {
                            for (int j = 0; j < levelFiveObjects.Count; ++j)
                            {
                                levelFiveObjects[j].SetActive(true);
                            }
                        }
                        else if (currentWave == 5)
                        {

                        }
                    }
                }
            }
            else
            {
                if (Time.time > nextWaveDelay)
                {
                    if (waveText.activeInHierarchy)
                    {
                        waveText.gameObject.SetActive(false);
                    }
                    if (hordeCollector.childCount < maxZombieInScene && zombieCounter < numberOfZombiesInWave)
                    {
                        if (Time.time > setDelay)
                        {
                            if (!spawnsContainNestedPoints)
                            {
                                if (i < transform.childCount)
                                {
                                    InstantiateZombie();
                                }
                                else
                                {
                                    var randomTime = Random.Range(minTime, maxTime);

                                    setDelay = randomTime;
                                    i = 0;
                                }
                            }
                            else
                            {
                                if (h < transform.childCount)
                                {
                                    if (transform.GetChild(h).gameObject.activeInHierarchy)
                                    {
                                        if (i < transform.GetChild(h).childCount)
                                        {
                                            InstantiateZombie();
                                        }
                                        else
                                        {
                                            var randomTime = Random.Range(minTime, maxTime);

                                            setDelay = randomTime;
                                            h++;
                                            i = 0;
                                        }
                                    }
                                    else
                                    {
                                        h++;
                                    }
                                }
                                else
                                {
                                    h = 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!waveText.activeInHierarchy)
                    {
                        SetWaveUI();
                    }
                }
            }
        }
        else
        {
            var allConditions = false;

            if (bossSpawn != null)
            {
                if(bossSpawn.totalBosses == 0 && hordeCollector.childCount == 0)
                {
                    allConditions = true;
                }
            }
            else
            {
                if (hordeCollector.childCount == 0)
                {
                    allConditions = true;
                }
            }

            if (allConditions)
            {
                if (triggerEvent != null)
                {
                    triggerEvent.SetActive(true);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
