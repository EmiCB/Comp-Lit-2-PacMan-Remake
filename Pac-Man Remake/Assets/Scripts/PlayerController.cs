using UnityEngine;
using UnityEngine.UI;

/// + = Add
/// - = Remove
/// 
/// NOTES:
/// + continuous movement
/// + animations
/// + function for displaying score

public class PlayerController : MonoBehaviour
{
    //Allows you to change varriables using the Unity inspector
    public float speed = 6.0F;
    public float gravity = 20.0F;

    //Sets Text scoreText
    public Text scoreText;

    //Adds a score integer
    private int score;

    void Start()
    {
        //Sets the score to zero
        score = 0;
        //Displays your current score
        scoreText.text = "Score: " + score.ToString();
    }

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

    //Pickups
    void OnTriggerEnter(Collider other)
    {
        // Picks up certain game objects witth the "Pellet" tag
        if (other.gameObject.CompareTag("Pellet"))
        {
            other.gameObject.SetActive(false);

            //Adds 10 points to your score
            score = score + 10;

            //Displays your current score
            scoreText.text = "Score: " + score.ToString();
        }

        // Picks up certain game objects witth the "PowerPellet" tag
        if (other.gameObject.CompareTag("PowerPellet"))
        {
            other.gameObject.SetActive(false);

            //Adds 50 points to your score
            score = score + 50;

            //Displays your current score
            scoreText.text = "Score: " + score.ToString();

            //ADD CODE TO ALLOW PLAYER TO EAT GHOSTS
        }

        // Picks up certain game objects witth the "Cherry" tag
        if (other.gameObject.CompareTag("Cherry"))
        {
            other.gameObject.SetActive(false);

            //Adds 100 points to your score
            score = score + 100;

            //Displays your current score
            scoreText.text = "Score: " + score.ToString();
        }

        // Picks up certain game objects witth the "Strawberry" tag
        if (other.gameObject.CompareTag("Strawberry"))
        {
            other.gameObject.SetActive(false);

            //Adds 300 points to your score
            score = score + 300;

            //Displays your current score
            scoreText.text = "Score: " + score.ToString();
        }

        // Picks up certain game objects witth the "Orange" tag
        if (other.gameObject.CompareTag("Orange"))
        {
            other.gameObject.SetActive(false);

            //Adds 500 points to your score
            score = score + 500;

            //Displays your current score
            scoreText.text = "Score: " + score.ToString();
        }
    }

}