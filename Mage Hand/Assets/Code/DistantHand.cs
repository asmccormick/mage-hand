using UnityEngine;
using System.Collections;

public class DistantHand : MonoBehaviour {

	private SendDamage _sendDamageScript;

	// Use this for initialization
	void Start () {
		_sendDamageScript = GetComponent<SendDamage>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		Debug.Log("distant hand collides with " + collision.gameObject.name);
		_sendDamageScript.SetTarget(collision.gameObject);
	}
}
