using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject cameraHolder;

    private Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void Movement(float directionX, float directionY)
    {
        cameraHolder.transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
        rb.MovePosition(rb.position + new Vector3(directionX * speed, 0.0f, directionY * speed) * Time.deltaTime);
    }
}
