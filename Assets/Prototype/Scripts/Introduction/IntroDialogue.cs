using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField]
    private float delay;
    private float setDelay;

    private bool fadeIn = true;

    [SerializeField]
    private List<TextMeshProUGUI> TMPFade;

    [SerializeField]
    private Playlist playerAudio;

    [SerializeField]
    private GameObject introTrigger;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject gameObjectToEnable;



    private void Awake()
    {
        gameManager.gameState++;
    }



    // Update is called once per frame
    void Update()
    {
        if (TMPFade.Count > 0)
        {
            if (fadeIn)
            {
                TMPFade[0].color = Color.Lerp(TMPFade[0].color, new Color(255.0f, 0.0f, 0.0f, 1.0f), Mathf.PingPong(Time.time / 50.0f, 10));

                if (TMPFade[0].color.a > 0.95f)
                {
                    fadeIn = false;

                    setDelay = delay + Time.realtimeSinceStartup;
                }
            }
            else
            {
                if (Time.realtimeSinceStartup > setDelay)
                {
                    TMPFade[0].color = Color.Lerp(TMPFade[0].color, new Color(255.0f, 0.0f, 0.0f, 0.0f), Mathf.PingPong(Time.time / 50.0f, 20));
                }

                if (TMPFade[0].color.a < 0.01f)
                {
                    fadeIn = true;

                    TMPFade[0].enabled = false;
                    
                    TMPFade.RemoveAt(0);
                }
            }
        }
        else
        {
            if(GetComponent<Image>().color.a > 0.01f)
            {
                GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, new Color(1.0f, 1.0f, 1.0f, 0.0f), Mathf.PingPong(Time.time / 50.0f, 10));
            }
            else
            {
                playerAudio.startMusic = true;
                introTrigger.SetActive(true);
                gameManager.gameState--;
                Destroy(gameObject);
            }
        }
    }

    private void OnDisable()
    {
        gameObjectToEnable.SetActive(true);
    }
}
