using UnityEngine;
using System.Collections;

public class NestTeleporter : MonoBehaviour {

	private GameObject _cameraRig;

	// Use this for initialization
	void Start () {
		_cameraRig = GameObject.Find("[CameraRig] modified");
		Debug.Log("camerarig = " + _cameraRig);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TeleportHere ()
	{
		_cameraRig.transform.position = transform.position;
	}
}
