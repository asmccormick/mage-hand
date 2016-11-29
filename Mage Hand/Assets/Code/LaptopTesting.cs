using UnityEngine;
using System.Collections;

public class LaptopTesting : MonoBehaviour {

	[SerializeField] private GameObject _leftController;
	[SerializeField] private GameObject _rightController;
	[SerializeField] private GameObject _head;
	[SerializeField] private float _rotateSpeed;
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _handRotSpeed;
	[SerializeField] private float _handMoveSpeed;
	[SerializeField] private SendDamage _sendDamageScript;
	[SerializeField] private AnimateRipple _animateRippleScript;


	void Start () {
		_leftController.SetActive(true);
		_rightController.SetActive(true);
		_head.transform.position = new Vector3(_head.transform.position.x, _head.transform.position.y + 1.6f, _head.transform.position.z);
		_leftController.transform.position = new Vector3(_leftController.transform.position.x -0.5f, _leftController.transform.position.y + 1.5f, _leftController.transform.position.z + 0.5f);
		_leftController.transform.Rotate(-90,0,0);
		_rightController.transform.position = new Vector3(_rightController.transform.position.x, _rightController.transform.position.y + 1.5f, _rightController.transform.position.z + 1.0f);
		_leftController.transform.SetParent(_head.transform);
		_rightController.transform.SetParent(_head.transform);
	}
	

	void Update () {
		// Move entire Rig
		// ---------------
		// turn Left
		if (Input.GetKey("q")) {_head.transform.Rotate(Vector3.up * -_rotateSpeed);}
		// turn Right
		if (Input.GetKey("e")) {_head.transform.Rotate(Vector3.up * _rotateSpeed);}
		// strafe Left
		if (Input.GetKey("a")) {_head.transform.Translate(Vector3.left * _moveSpeed);}
		// strafe Right
		if (Input.GetKey("d")) {_head.transform.Translate(Vector3.right * _moveSpeed);}
		// move Forward
		if (Input.GetKey("w")) {_head.transform.Translate(Vector3.forward * _moveSpeed);}
		// move Bacdward
		if (Input.GetKey("s")) {_head.transform.Translate(Vector3.forward * -_moveSpeed);}
			
		// Move Right Hand
		// ---------------
		// rotate Left
		if (Input.GetKey(KeyCode.LeftArrow)) {_rightController.transform.RotateAround(_head.transform.position, Vector3.up, -_handRotSpeed);}
		// rotate Right
		if (Input.GetKey(KeyCode.RightArrow)) {_rightController.transform.RotateAround(_head.transform.position, Vector3.up, _handRotSpeed);}
		// rotate Up
		if (Input.GetKey(KeyCode.UpArrow)) {_rightController.transform.RotateAround(_head.transform.position, _head.transform.TransformDirection(Vector3.right), -_handRotSpeed);}
		// rotate Down
		if (Input.GetKey(KeyCode.DownArrow)) {_rightController.transform.RotateAround(_head.transform.position, _head.transform.TransformDirection(Vector3.right), _handRotSpeed);}
		// move Forward
		if (Input.GetKey("r")) {_rightController.transform.Translate(Vector3.forward * _handMoveSpeed);}
		// move Backward
		if (Input.GetKey("f")) {_rightController.transform.Translate(Vector3.forward * -_handMoveSpeed);}

		// Damage Target
		if (Input.GetKey(KeyCode.Space)) 
		{
			_sendDamageScript.DamageTarget();
			_animateRippleScript.Burst();
		}
	}
}
