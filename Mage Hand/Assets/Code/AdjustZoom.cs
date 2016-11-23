using UnityEngine;
using System.Collections;

public class AdjustZoom : MonoBehaviour {

	[SerializeField] private Transform _rightController;
	private Camera _lensCamera;

	// Use this for initialization
	void Start () {
		_lensCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		// find relative position (distance) of right controller
		Vector3 distance = _rightController.position - transform.position;
		Vector3 relativePosition = Vector3.zero;
		relativePosition.x = Vector3.Dot(distance, transform.right.normalized);
		relativePosition.y = Vector3.Dot(distance, transform.up.normalized);
		relativePosition.z = Vector3.Dot(distance, transform.forward.normalized);	// we really only need Z, not X and Y

		// adjust FOV (zoom)
		float _newFov = 60 - (relativePosition.z * 100);
		if (_newFov > 60) {_newFov = 60;}
		if (_newFov < 10) {_newFov = 10;}
		_lensCamera.fieldOfView = _newFov;
	}
}
