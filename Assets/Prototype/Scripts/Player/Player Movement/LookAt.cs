using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private GameManager gameManager;



    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == 0)
        {
            var angle = Vector3.SignedAngle(new Vector3(camera.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 0.0f, camera.ScreenToWorldPoint(Input.mousePosition).z - transform.position.z), Vector3.forward, Vector3.up);
            transform.eulerAngles = new Vector3(0, -angle, 0);
        }
    }
}
