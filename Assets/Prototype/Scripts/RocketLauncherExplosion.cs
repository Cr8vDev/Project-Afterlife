using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherExplosion : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> explosion;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float delay;
    private float setdelay;
    private int increment = 0;

    void Update()
    {
        if (increment < explosion.Count)
        {
            if (Time.time > setdelay)
            {
                if(increment == 0)
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
