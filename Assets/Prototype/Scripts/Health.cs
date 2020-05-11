using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CharacterType
{
    Human,
    Horde,
    Roamer,
    Boss
}

public class Health : MonoBehaviour
{
    [HideInInspector]
    public HordeSpawn hordeSpawn;
    [HideInInspector]
    public BossSpawn bossSpawn;
    [SerializeField]
    private GameObject objectToDestroy;
    [SerializeField]
    private int health;
    [SerializeField]
    private TextMeshProUGUI healthUI;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private CharacterType characterType;

    [SerializeField]
    private float damageIndicatorDelayForPlayerOnly;
    [HideInInspector]
    public float setIndicatorDelay = 0f;

    [HideInInspector]
    public bool triggerDamageIndicator = false;

    public Image damageIndicatorForPlayerOnly;

    private bool deathTrigger = false;

    public void Start()
    {
        if (characterType == CharacterType.Human)
        {
            if (healthUI != null)
            {
                healthUI.text = "Health: " + health;
            }
        }
    }

    public void Heal(int value)
    {
        var totalHeal = health + value;

        if(totalHeal > 100)
        {
            health = 100;
        }
        else
        {
            health += value;
        }

        healthUI.text = "Health: " + health.ToString();
    }

    public void DealDamage(int amount)
    {
        health -= amount;

        if (characterType == CharacterType.Human)
        {
            healthUI.text = "Health: " + health;

            damageIndicatorForPlayerOnly.color = new Color(1f, 0f, 0f, 1f);

            setIndicatorDelay = Time.time + damageIndicatorDelayForPlayerOnly;

            triggerDamageIndicator = true;
        }

        if(health <= 0 && !deathTrigger)
        {
            deathTrigger = true;

            if (characterType == CharacterType.Human)
            {
                if (healthUI != null)
                {
                    gameOver.gameObject.SetActive(true);
                }

                Cursor.visible = true;
            }

            if (characterType == CharacterType.Horde)
            {
                if (bossSpawn != null)
                {
                    bossSpawn.zombiesAlreadyKilled++;
                }
            }

            Destroy(objectToDestroy);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnDestroy()
    {
    }
}
