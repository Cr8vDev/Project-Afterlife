using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField]
    private float delay;
    private float setDelay = 0.0f;
    private bool showMessage = false;

    private Image image;
    private TextMeshProUGUI messageText;

    private Vector3 initialPos;

    private void Awake()
    {
        image = GetComponent<Image>();
        messageText = GetComponentInChildren<TextMeshProUGUI>();
        initialPos = transform.position;
    }

    public void SetMessage(string sMessage)
    {
        transform.position = initialPos;

        showMessage = true;
        messageText.text = sMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (showMessage)
        {
            if (Time.time > setDelay)
            {
                if (image.color.a > 0.95f)
                {
                    image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                    messageText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    showMessage = false;
                }
                else
                {
                    transform.position += new Vector3(0.0f, 1.0f, 0.0f);
                    image.color += new Color(0.0f, 0.0f, 0.0f, 0.075f);
                    messageText.color += new Color(0.0f, 0.0f, 0.0f, 0.075f);
                    setDelay = Time.time + delay;
                }
            }
        }
    }
}
