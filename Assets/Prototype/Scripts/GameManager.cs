using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gameState;

    [SerializeField]
    private GameObject quit;

    private void Awake()
    {
        StaticDataContainer.gameManager = this;
    }

    private bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                gameState++;
                paused = true;

                quit.SetActive(true);
            }
            else
            {
                gameState--;
                paused = false;

                quit.SetActive(false);
            }
        }
    }
}
