using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoto : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float VerticalVelocity = 0.0f;
    private float gravity = 24.0f;


    private float animationDuration = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }


        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            VerticalVelocity = -0.5f;
        }
        else
        {
            VerticalVelocity -= gravity * Time.deltaTime;
        }

        //x Left and right

        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;

        //y Up and Down
        moveVector.y = VerticalVelocity;


        //z Forward and backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
}
