using UnityEngine;
using System.Collections;

/// NOTES:
/// The orange ghost tracks like the red ghost, but once it gets into a certain range, 
/// will go to the bottom left corner until it is out of that range.

public class OrangeGhostController : MonoBehaviour 
{
	

	// Sets player transform and nav mesh agent
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;

	void Start ()
	{
		// Find player location
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		// Gets Nav Mesh Agent - enemy pathing
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}

	void Update ()
	{
		// Follows player directly
		nav.SetDestination (player.position);
	}
}
