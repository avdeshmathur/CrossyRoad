using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int currentLane = 0;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane == -2) return;
            MoveLeft();
            currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane == 2) return;
            MoveRight();
            currentLane++;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = (Vector3.forward * speed * Time.fixedDeltaTime);
    }

    void MoveLeft()
    {
        
    }

    void MoveRight()
    {
        
    }
}
