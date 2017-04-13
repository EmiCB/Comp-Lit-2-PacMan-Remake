using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour 
{

	public GameObject player;

	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;

		//Locks direction the player is facing so that it matches the direction the player is moving
		if (Input.GetKeyDown(KeyCode.UpArrow))
			transform.forward = new Vector3(0f, 0f, 1f); //Faces North when UpArrow is pressed
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			transform.forward = new Vector3(0f, 0f, -1f); //Faces South when DownArrow is pressed
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			transform.forward = new Vector3(-1f, 0f, 0f); //Faces West when LeftArrow is pressed
		else if (Input.GetKeyDown(KeyCode.RightArrow))
			transform.forward = new Vector3(1f, 0f, 0f); //Faces East when RightArrow is pressed
	}
}