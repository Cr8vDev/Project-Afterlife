using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnEnable : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private List<GameObject> disableUI;

    private void OnEnable()
    {
        gameManager.gameState++;


        if (disableUI.Count > 0)
        {
            for (int i = 0; i < disableUI.Count; ++i)
            {
                disableUI[i].SetActive(false);
            }
        }
    }
}
