using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour
    {

        private Animator anim;
        private CharacterController controller;

        public float speed = 600.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 20.0f;
        public float jumpForce = 500.0f;
        private bool isJumping = false;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();

        }

        void Update()
        {
          //

            {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = 0;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetKey("w"))
        {
            moveY = -speed * Time.deltaTime;
            moveZ = 0;
        }

        Vector3 movement = new Vector3(moveX, moveY, moveZ);
        controller.Move(movement);
    }

            //

            

            if (controller.isGrounded)
            {
                
                    anim.SetTrigger("Grounded");


                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    anim.SetTrigger("Wave");
                }

                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");

                if (verticalInput == 1 || horizontalInput != 0)
                {
                    anim.SetInteger("AnimationPar", 1);
                }
                else
                {
                    anim.SetInteger("AnimationPar", 0);
                }





                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                if (Input.GetKeyDown("space"))
                {
                    isJumping = true;
                }
            }


           

            if (isJumping)
            {

                moveDirection.y += jumpForce * Time.deltaTime;
                if (controller.isGrounded)
                {
                    isJumping = false;
                }
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}
