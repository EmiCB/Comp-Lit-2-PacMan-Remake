using UnityEngine;
using System.Collections;

/// NOTES:
/// The blue ghost draws a point a couple units in front of the player, then draws a line through it.
/// The line connects with the red ghost.
/// The blue ghost will follow a pont at the end of the line oppposite the red ghost.
/// The distance of the dot is equal to the red ghost's distance from the player.
/// This is the hardest ghost to program.

public class BlueGhostController : MonoBehaviour 
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
