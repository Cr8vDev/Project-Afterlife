using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private float delay = 15f;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<TextMeshProUGUI>().color.a < 0.99f)
        {
            GetComponent<TextMeshProUGUI>().color += new Color(0f, 0f, 0f, 0.01f);
        }

        if(Time.time > delay)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
