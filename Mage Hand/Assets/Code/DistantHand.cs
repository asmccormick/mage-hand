using UnityEngine;
using System.Collections;

public class DistantHand : MonoBehaviour {

	private SendDamage _sendDamageScript;

	void Start () 
	{
		_sendDamageScript = GetComponent<SendDamage>();
	}

	void OnCollisionEnter (Collision collision)
	{
		_sendDamageScript.SetTarget(collision.gameObject);
	}
}
