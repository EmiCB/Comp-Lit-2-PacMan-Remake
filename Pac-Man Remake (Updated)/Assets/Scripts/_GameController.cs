using UnityEngine;
using System.Collections;

/// + = Add
/// - = Remove
/// 
/// NOTES:
/// + code to spawn objects at random points in each map
/// + ghost house code
/// 
/// move score here
/// move game over here
/// move lives here
/// move restart here

public class _GameController : MonoBehaviour 
{
	// Sets gameobject ready
	public GameObject ready;
	// Ghosts
	public GameObject ghostRed;
	public GameObject ghostPink;
	public GameObject ghostOrange;
	public GameObject ghostBlue;

	// Sets time
	public float StartWait = 4;

	IEnumerator Start ()
	{
		// Waits for 4 seconds
		yield return new WaitForSeconds(StartWait);
		ready.gameObject.SetActive(false);

		// Red ghost
		yield return new WaitForSeconds(1);
		ghostRed.gameObject.SetActive (true);

		// Pink ghost
		yield return new WaitForSeconds(5);
		ghostPink.gameObject.SetActive (true);

		// Orange ghost
		yield return new WaitForSeconds(10);
		ghostOrange.gameObject.SetActive (true);

		// Blue ghost
		yield return new WaitForSeconds(20);
		ghostBlue.gameObject.SetActive (true);
	}
}
