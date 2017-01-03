using UnityEngine;
using System.Collections;

public class RaycastFromLens : MonoBehaviour {

	[SerializeField] private Transform _distantHand;
	public Transform _cameraEye;
	public Transform _rightController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Raycast();
	}

	public void Raycast() {
		//Vector3 _fwd = transform.TransformDirection(Vector3.forward);
		//Vector3 _fwd = _cameraEye.transform.TransformDirection(Vector3.forward);
		//Vector3 _fwd = _cameraEye.position - _rightController.position;
		Vector3 _relativePos =  _rightController.position - _cameraEye.position;
		Quaternion _rotation = Quaternion.LookRotation (_relativePos);


		Vector3 _fwd = _rotation * Vector3.forward;
		RaycastHit _hit;
		Debug.DrawRay(_cameraEye.transform.position, _fwd * 100, Color.green, 1);
		if (Physics.Raycast (_cameraEye.transform.position, _fwd, out _hit)) {
			{
				_distantHand.position = _hit.point;
			}
		} else {
			_distantHand.position = _cameraEye.transform.position + _fwd * 100;
		}
	}
}
