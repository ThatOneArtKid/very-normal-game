using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class playeridk : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("collectible"))
        {
        other.gameObject.SetActive(false);
        count = count + 1;
        }


    }
}
