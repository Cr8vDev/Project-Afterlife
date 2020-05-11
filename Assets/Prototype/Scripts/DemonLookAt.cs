using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private List<Sprite> up;
    [SerializeField]
    private List<Sprite> down;
    [SerializeField]
    private List<Sprite> left;
    [SerializeField]
    private List<Sprite> right;

    [SerializeField]
    private float animationDelay;
    private float setAnimationDelay;

    private int animationIncrement = 0;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Update()
    {
        var angle = Vector3.SignedAngle(transform.forward, Vector3.forward, Vector3.up);

        if(angle < 135 && angle > 45)
        {
            if(Time.time > setAnimationDelay)
            {
                if(left.Count > animationIncrement)
                {
                    spriteRenderer.sprite = left[animationIncrement];
                    setAnimationDelay = Time.time + animationDelay;
                    animationIncrement++;
                }
                else
                {
                    animationIncrement = 0;
                }
            }
        }
        else if(angle < 45 && angle > -45)
        {
            if (Time.time > setAnimationDelay)
            {
                if (up.Count > animationIncrement)
                {
                    spriteRenderer.sprite = up[animationIncrement];
                    setAnimationDelay = Time.time + animationDelay;
                    animationIncrement++;
                }
                else
                {
                    animationIncrement = 0;
                }
            }
        }
        else if (angle < -45 && angle > -135)
        {
            if (Time.time > setAnimationDelay)
            {
                if (right.Count > animationIncrement)
                {
                    spriteRenderer.sprite = right[animationIncrement];
                    setAnimationDelay = Time.time + animationDelay;
                    animationIncrement++;
                }
                else
                {
                    animationIncrement = 0;
                }
            }
        }
        else
        {
            if (Time.time > setAnimationDelay)
            {
                if (down.Count > animationIncrement)
                {
                    spriteRenderer.sprite = down[animationIncrement];
                    setAnimationDelay = Time.time + animationDelay;
                    animationIncrement++;
                }
                else
                {
                    animationIncrement = 0;
                }
            }
        }
    }
}
