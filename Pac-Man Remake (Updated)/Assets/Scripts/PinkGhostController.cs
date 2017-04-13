using UnityEngine;
using System.Collections;

/// NOTES:
/// The pink ghost tracks a point several units in front of the player.

public class PinkGhostController : MonoBehaviour 
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
