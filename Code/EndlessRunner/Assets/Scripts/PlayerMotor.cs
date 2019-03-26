using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity = 0.0f;
    private float gravity = 20.0f;
    private float jumpSpeed = 9.0f;

    private float speed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        /* moveVector = Vector3.zero;


         /*if(controller.isGrounded)
         {
             verticalVelocity = -0.5f;
         } else
         {
             verticalVelocity -= gravity * Time.deltaTime; 
         } 

         if (controller.isGrounded){         
             if ( Input.GetMouseButtonDown(0))
             {
                 moveVector.y = jumpVelocity;
             }
         }




         moveVector.y = moveVector.y - (gravity * Time.deltaTime);

         moveVector.z = speed;

         controller.Move(moveVector * Time.deltaTime);*/


        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, speed);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetMouseButtonDown(0))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
           restartCurrentScene();
    }

    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
