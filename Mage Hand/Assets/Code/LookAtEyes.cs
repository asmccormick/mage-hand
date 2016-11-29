using UnityEngine;
using System.Collections;

public class LookAtEyes : MonoBehaviour {

	[SerializeField] private Transform _cameraEyes;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(_cameraEyes);
	}
}