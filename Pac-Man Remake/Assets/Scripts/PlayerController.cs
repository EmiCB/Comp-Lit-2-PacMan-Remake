using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Allows you to change varriables using the Unity inspector
    public float speed = 6.0F;
    public float gravity = 20.0F;

    //Movement using the Player Controller component in Unity
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //Locks direction the player is facing so that it matches the direction the player is moving
            if (Input.GetKeyDown(KeyCode.UpArrow))
                transform.forward = new Vector3(1f, 0f, 0f); //Faces North when UpArrow is pressed
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                transform.forward = new Vector3(-1f, 0f, 0f); //Faces South when DownArrow is pressed
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.forward = new Vector3(0f, 0f, 1f); //Faces West when LeftArrow is pressed
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.forward = new Vector3(0f, 0f, -1f); //Faces East when RightArrow is pressed
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}