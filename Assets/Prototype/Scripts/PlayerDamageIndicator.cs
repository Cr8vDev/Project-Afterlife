using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageIndicator : MonoBehaviour
{
    [SerializeField]
    private Health playerHealth;

    private void Update()
    {
        if (playerHealth.triggerDamageIndicator)
        {
            if (Time.time > playerHealth.setIndicatorDelay)
            {
                playerHealth.damageIndicatorForPlayerOnly.color = new Color(1f, 0f, 0f, 0f);

                playerHealth.triggerDamageIndicator = false;
            }
        }
    }
}
