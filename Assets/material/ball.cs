using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direction;
    public float Forwardspeed = 10;
    
    private int desiredlane = 1;// 0 as left 1 is middle and 2 is right 
    public float lanedistance = 4;// dis b/w 2 lanes 

    public float jumpForce; //jump related variables 
    public float Gravity = -5;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = Forwardspeed;
        
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredlane++;
            if (desiredlane == 3)
            {
                desiredlane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredlane--;
            if (desiredlane == -1)
            {
                desiredlane = 0;
            }

        } Vector3 targetpositon = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredlane == 0)
        {
            targetpositon += Vector3.left * lanedistance;
        }
        else if (desiredlane == 2)
        {
            targetpositon += Vector3.right * lanedistance;
        }
       transform.position = Vector3.Lerp(transform.position, targetpositon, 120* Time.deltaTime);
    }


private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
         direction.y = jumpForce;
    }
}
