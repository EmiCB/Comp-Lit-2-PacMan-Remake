using UnityEngine;
using System.Collections;

public class Cameras : MonoBehaviour 
{
	public Camera firstPersonCamera;
	public Camera overheadCamera;

	public void ShowOverheadView() 
	{
		firstPersonCamera.enabled = false;
		overheadCamera.enabled = true;
	}

	public void ShowFirstPersonView() 
	{
		firstPersonCamera.enabled = true;
		overheadCamera.enabled = false;
	}
}
