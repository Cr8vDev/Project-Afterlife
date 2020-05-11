using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls player movement, animations and UI.

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private bool enableAnimations = false;

    [HideInInspector]
    public float yDirection;
    [HideInInspector]
    public float xDirection;

    private CharacterAnimation characterAnimation;

    private CharacterMovement characterMovement;

    [SerializeField]
    private GameManager gameManager;



    // Start is called before the first frame update
    void Awake()
    {
        if (enableAnimations)
        {
            characterAnimation = GetComponent<CharacterAnimation>();
        }

        characterMovement = GetComponent<CharacterMovement>();
    }



    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameState == 0)
        {
            yDirection = Input.GetAxis("Vertical");
            xDirection = Input.GetAxis("Horizontal");

            if (enableAnimations)
            {
                if (yDirection > 0.1f)
                {
                    characterAnimation.Upward();
                }
                else if (yDirection < -0.1f)
                {
                    characterAnimation.Downward();
                }
                else if (xDirection > 0.1f)
                {
                    characterAnimation.Right();
                }
                else if (xDirection < -0.1f)
                {
                    characterAnimation.Left();
                }
            }

            characterAnimation.UpperBody();
        }
    }



    private void FixedUpdate()
    {
        if (gameManager.gameState == 0)
        {
            characterMovement.Movement(xDirection, yDirection);
        }
        else
        {
            characterMovement.Movement(0, 0);
        }
    }
}
