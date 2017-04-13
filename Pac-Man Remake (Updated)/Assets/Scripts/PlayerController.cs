using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// + = Add
/// - = Remove
/// 
/// NOTES:
/// + continuous movement
/// + animations
/// + sounds
/// 
/// DONT FORGET TO FIX AND UNCOMMENT TIME

public class PlayerController : MonoBehaviour
{
	
// Public allows you to change varriables using the Unity inspector
	//Sets speed and gravity
    public float speed = 6.0F;
    public float gravity = 20.0F;
	// Time that power pellet is effective
	public float eatTime = 1.0F;
	public float timer;

    // Sets integers
    private int score = 0;
	private int lives = 3;
	// Sets ghosts eaten
	private int ghostsEaten = 0;
	// Sets a number of deaths
	//private int deaths = 0;

	// Sets texts
	public Text scoreText;
	public Text livesText;
	public Text restartText;

	//
	private static IDictionary<string, int> fruitPointValues = new Dictionary<string, int> {
		{"Cherry", 100}, {"Strawberry", 300},{"Orange", 500}, {"Apple", 700}, {"Pineapple", 1000}, {"Galaxian Spaceship", 2000}, {"Bell", 3000}, {"Key", 5000},
	};
		
	// Sets booleans
	private bool powerPelletActive;
	private bool gameOver;
	private bool restart;
	private bool wait;

	// Sounds
	private AudioSource deathSound; 

    IEnumerator Start()
	{
		// Sets gameOver to false
		gameOver = false;
		// Sets restart to flase
		restart = false;
		// Sets powerPelletActive to flase
		powerPelletActive = false;
		// Sets wait to true
		wait = true;
        // Sets the score to zero
        score = 0;
		// Sets the lives to 3
		lives = 3;
		// Sets time to 11
		timer = 1.1F;
        // Displays your current score
        scoreText.text = "Score: " + score.ToString();
		// Displays your current lives
		livesText.text = "Lives: " + lives.ToString();

		deathSound = GetComponent<AudioSource>();

		// Waits for 5 seconds
		yield return new WaitForSeconds(5);
		wait = false;
    }

    //Movement using the Player Controller component in Unity
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
		CharacterController controller = GetComponent<CharacterController>();
		if (wait == false)
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

			Debug.Log ("time: " + Time.time);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

		// DO NOT USE A WHILE LOOP
		// Timer
		if (powerPelletActive == true && timer <= eatTime) 
		{
			Debug.Log (timer);

			timer += Time.deltaTime;

			Debug.Log (timer);
		}
		else 
		{
			powerPelletActive = false;
		}

		if (lives == 0) 
		{
			GameOver ();
		}

		if (gameOver == true) 
		{
			restartText.text = "Press 'R' For Restart";
			restart = true;
		}
    }

	void OnPelletEnter(Collider other)
	{
		other.gameObject.SetActive (false);

		// Adds 10 points to your score
		score = score + 10;

		// Displays your current score
		scoreText.text = "Score: " + score.ToString ();
	}

	void OnPowerPelletEnter (Collider other)
	{
		other.gameObject.SetActive (false);

		// Adds 50 points to your score
		score = score + 50;

		// Displays your current score
		scoreText.text = "Score: " + score.ToString ();

		// Starts timer & sets stuff
		powerPelletActive = true;
		timer = 0.0F;
		ghostsEaten = 0;
	}

	void OnFruitEnter(Collider other, string fruitName)
	{
		other.gameObject.SetActive (false);

		if (fruitPointValues.ContainsKey (fruitName)) {
			int fruitScore = fruitPointValues [fruitName];

			// Adds 100 points to your score
			score = score + fruitScore;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();		
		}
		else 
		{
			Debug.Log ("Fruit not found: " + fruitName);
		}
	}

	void OnGhostEnter (Collider other)
	{
		// Death
		if (powerPelletActive == false) 
		{
			deathSound.Play();

			lives = lives - 1;

			livesText.text = "Lives: " + lives.ToString ();

			score = 0;
			scoreText.text = "Score: " + score.ToString ();

			this.gameObject.SetActive (false);
		}
		// Eat ghosts
		else if (powerPelletActive == true) 
		{
			if (timer <= eatTime) 
			{
				if (ghostsEaten == 0) 
				{
					// Adds 200 points to your score
					score = score + 200;

					// Displays your current score
					scoreText.text = "Score: " + score.ToString ();

					// Gets rid of other gameobject
					other.gameObject.SetActive (false);

					// Adds 1 to ghosts eaten
					ghostsEaten = ghostsEaten + 1;
				} 
				else if (ghostsEaten == 1) 
				{
					// Adds 400 points to your score
					score = score + 400;

					// Displays your current score
					scoreText.text = "Score: " + score.ToString ();

					// Gets rid of other gameobject
					other.gameObject.SetActive (false);

					// Adds 1 to ghosts eaten
					ghostsEaten = ghostsEaten + 1;
				} 
				else if (ghostsEaten == 2) 
				{
					// Adds 800 points to your score
					score = score + 800;

					// Displays your current score
					scoreText.text = "Score: " + score.ToString ();

					// Gets rid of other gameobject
					other.gameObject.SetActive (false);

					// Adds 1 to ghosts eaten
					ghostsEaten = ghostsEaten + 1;
				} 
				else if (ghostsEaten == 3) 
				{
					// Adds 1600 points to your score
					score = score + 1600;

					// Displays your current score
					scoreText.text = "Score: " + score.ToString ();

					// Gets rid of other gameobject
					other.gameObject.SetActive (false);

					// Resets ghosts eaten
					ghostsEaten = 0;
				}
			}
			else 
			{
				powerPelletActive = false;
			}
		}
	}

    // When the game object touches something
    void OnTriggerEnter(Collider other)
	{
		// Score system:
		// Picks up certain game objects with the "Pellet" tag
		if (other.gameObject.CompareTag ("Pellet")) 
		{
			OnPelletEnter (other);
		}

		// Picks up certain game objects with the "PowerPellet" tag
		if (other.gameObject.CompareTag ("PowerPellet")) 
		{
			OnPowerPelletEnter (other);
		}

		// Picks up certain game objects with the "Cherry" tag
		if (other.gameObject.CompareTag ("Cherry")) 
		{
			OnFruitEnter (other, "Cherry");
		}

		// Picks up certain game objects with the "Strawberry" tag
		if (other.gameObject.CompareTag ("Strawberry")) 
		{
			OnFruitEnter (other, "Strawberry");
		}

		// Picks up certain game objects with the "Orange" tag
		if (other.gameObject.CompareTag ("Orange")) 
		{
			OnFruitEnter (other, "Orange");
		}

		// Picks up certain game objects with the "Apple" tag
		if (other.gameObject.CompareTag ("Apple")) 
		{
			OnFruitEnter (other, "Apple");
		}

		// Picks up certain game objects with the "Pineapple" tag
		if (other.gameObject.CompareTag ("Pineapple")) 
		{
			OnFruitEnter (other, "Pineapple");
		}

		// Picks up certain game objects with the "Galaxian Spaceship" tag
		if (other.gameObject.CompareTag ("Galaxian Spaceship")) 
		{
			OnFruitEnter (other, "Galaxian Spaceship");
		}

		// Picks up certain game objects with the "Bell" tag
		if (other.gameObject.CompareTag ("Bell")) 
		{
			OnFruitEnter (other, "Bell");
		}

		// Picks up certain game objects with the "Key" tag
		if (other.gameObject.CompareTag ("Key")) 
		{
			OnFruitEnter (other, "Key");
		}

		//Ghost interactions
		if (other.gameObject.CompareTag ("Ghost"))
		{
			OnGhostEnter (other);
		}
    }

	public void GameOver()
	{
		gameOver = true;
	}
}