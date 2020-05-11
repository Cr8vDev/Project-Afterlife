using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int maxDistance;
    [SerializeField]
    private float speed;

    private Vector3 initial;

    private void Start()
    {
        initial = transform.position;
    }

    void Update()
    {
        if (StaticDataContainer.gameManager.gameState == 0)
        {
            if (Vector3.Distance(initial, transform.position) > maxDistance)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }
    }
}
