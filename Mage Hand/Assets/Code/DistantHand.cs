using UnityEngine;
using System.Collections;

public class DistantHand : MonoBehaviour {

	private SendDamage _sendDamageScript;
	[SerializeField] private Transform _rightController;

	void Start () 
	{
		_sendDamageScript = GetComponent<SendDamage>();
	}

	void Update ()
	{
		transform.rotation = _rightController.rotation;
	}

	void OnCollisionEnter (Collision collision)
	{
		_sendDamageScript.SetTarget(collision.gameObject);
	}
}
