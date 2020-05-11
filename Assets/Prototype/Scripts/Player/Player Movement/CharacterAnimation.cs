using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpperDirection
{
    Left,
    Right,
    Up,
    Down
}

public class CharacterAnimation : MonoBehaviour
{
    private UpperDirection direction;

    [SerializeField]
    private float delay;
    private float setDelay;

    [SerializeField]
    private SpriteRenderer upperBody;
    [SerializeField]
    private SpriteRenderer lowerBody;

    [SerializeField]
    private List<Sprite> upward;
    [SerializeField]
    private List<Sprite> downward;
    [SerializeField]
    private List<Sprite> left;
    [SerializeField]
    private List<Sprite> right;
    [SerializeField]
    private List<Sprite> reverseUp;
    [SerializeField]
    private List<Sprite> reverseDown;

    [SerializeField]
    private Sprite upperUp;
    [SerializeField]
    private Sprite upperDown;
    [SerializeField]
    private Sprite upperLeft;
    [SerializeField]
    private Sprite upperRight;

    [SerializeField]
    private Transform weaponSpawn;

    private int i = 0;

    public new Camera camera;



    private void Awake()
    {
        setDelay = delay + Time.realtimeSinceStartup;
    }



    public void Upward()
    {
        if (Time.realtimeSinceStartup > setDelay)
        {
            if (i < upward.Count)
            {
                lowerBody.flipX = false;

                if (direction == UpperDirection.Down)
                {
                    lowerBody.sprite = reverseUp[i];
                }
                else
                {
                    lowerBody.sprite = upward[i];
                }

                ++i;
                setDelay = Time.realtimeSinceStartup + delay;
            }
            else
            {
                i = 0;
            }
        }
    }



    public void Downward()
    {
        if (Time.realtimeSinceStartup > setDelay)
        {
            if (i < downward.Count)
            {
                lowerBody.flipX = false;

                if (direction == UpperDirection.Up)
                {
                    lowerBody.sprite = reverseDown[i];
                }
                else
                {
                    lowerBody.sprite = downward[i];
                }

                ++i;
                setDelay = Time.realtimeSinceStartup + delay;
            }
            else
            {
                i = 0;
            }
        }
    }



    public void Left()
    {
        if (Time.realtimeSinceStartup > setDelay)
        {
            if (i < left.Count)
            {
                if (direction == UpperDirection.Right)
                {
                    lowerBody.flipX = false;
                }
                else
                {
                    lowerBody.flipX = true;
                }
                lowerBody.sprite = left[i];
                ++i;
                setDelay = Time.realtimeSinceStartup + delay;
            }
            else
            {
                i = 0;
            }
        }
    }



    public void Right()
    {
        if (Time.realtimeSinceStartup > setDelay)
        {
            if (i < right.Count)
            {
                if (direction == UpperDirection.Left)
                {
                    lowerBody.flipX = true;
                }
                else
                {
                    lowerBody.flipX = false;
                }
                lowerBody.sprite = right[i];
                ++i;
                setDelay = Time.realtimeSinceStartup + delay;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void UpperBody()
    {
        var angle = Vector3.SignedAngle(Vector3.forward, new Vector3(camera.ScreenToWorldPoint(Input.mousePosition).x, 0.0f, camera.ScreenToWorldPoint(Input.mousePosition).z) - new Vector3(transform.position.x, 0.0f, transform.position.z), Vector3.up);

        if (angle < 135 && angle > 45)
        {
            weaponSpawn.localPosition = new Vector3(0.1f, 0.05f, 0f);
            direction = UpperDirection.Right;
            upperBody.flipX = false;
            upperBody.sprite = upperRight;
        }
        else if(angle < 45 && angle > -45)
        {
            weaponSpawn.localPosition = new Vector3(0f, 0.15f, 0f);
            direction = UpperDirection.Up;
            upperBody.flipX = false;
            upperBody.sprite = upperUp;
        }
        else if (angle < -45 && angle > -135)
        {
            weaponSpawn.localPosition = new Vector3(-0.1f, 0.05f, 0f);
            direction = UpperDirection.Left;
            upperBody.flipX = true;
            upperBody.sprite = upperRight;
        }
        else
        {
            weaponSpawn.localPosition = new Vector3(-0.02f, 0f, 0f);
            direction = UpperDirection.Down;
            upperBody.flipX = false;
            upperBody.sprite = upperDown;
        }
    }
}
