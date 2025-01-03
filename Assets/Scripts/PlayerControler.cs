using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    private float laneDistance = 1.7f;
    public float jumpForce;
    public float Gravity = -20;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane > 2) // Change condition from == 3 to > 2
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane < 0) // Change condition from == -1 to < 0
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position;


        if (desiredLane == 0)
        {
            targetPosition.x = -laneDistance; // Move to the left lane
        }
        else if (desiredLane == 2)
        {
            targetPosition.x = laneDistance; // Move to the right lane
        }

        transform.position = targetPosition;
  
        //controller.center = controller.center;
        /*if (transform.position == targetPosition)
            return;
        Vector3 diff =targetPosition-transform.position;
        Vector3 moveDir=diff.normalized*25*Time.deltaTime;
        if(moveDir.sqrMagnitude <diff.sqrMagnitude)
        controller.Move(moveDir); 
        else controller.Move(moveDir); ;*/
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
       
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllercolliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}

