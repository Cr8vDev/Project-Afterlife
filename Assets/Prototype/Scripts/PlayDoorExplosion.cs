using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorExplosion : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> explosion;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float delay;
    private float setdelay;
    private int increment = 0;

    [SerializeField]
    private GameObject door;

    private void OnEnable()
    {
        Destroy(door);
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (increment < explosion.Count)
            {
                if (Time.time > setdelay)
                {
                    if (increment == 0)
                    {
                        StaticDataContainer.cameraExplosionEffect.ShakeCamera();
                    }

                    spriteRenderer.sprite = explosion[increment];
                    increment++;
                    setdelay = Time.time + delay;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
