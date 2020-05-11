using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField]
    private Image end;
    [SerializeField]
    private SpeechUI speechUI;
    [SerializeField]
    private TextMeshProUGUI fontChange;
    [SerializeField]
    private TMP_FontAsset fontAsset;

    [SerializeField]
    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioSource endSound;

    private void Start()
    {
        playerAudioSource.enabled = false;
        endSound.Play();
    }

    void Update()
    {
        if (end.color.a < 0.98f)
        {
            end.color += new Color(0.0f, 0.0f, 0.0f, 0.01f);
            end.gameObject.SetActive(true);
            fontChange.font = fontAsset;
            fontChange.color = Color.white;
        }
        else
        {
            speechUI.SetMessage(GetComponent<Speech>().message, "End");
            speechUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
