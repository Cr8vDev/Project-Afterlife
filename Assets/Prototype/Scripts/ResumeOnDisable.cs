using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeOnDisable : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private List<GameObject> enableUI;

    private void OnDisable()
    {
        gameManager.gameState--;

        if (enableUI.Count > 0)
        {
            for (int i = 0; i < enableUI.Count; ++i)
            {
                enableUI[i].SetActive(true);
            }
        }
    }
}
