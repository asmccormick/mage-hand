using UnityEngine;
using System.Collections;

public class HandsTakeDamage : MonoBehaviour {

	[SerializeField] private PlayerHealth _playerHealthScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Projectile")
		{
			Debug.Log("bullet hit player collider");
			_playerHealthScript.HandsTakeDamage();
		}
	}

	void OnTriggerEnter (Collider collision)
	{
		if (collision.gameObject.tag == "Projectile")
		{
			Debug.Log("bullet hit player trigger");	
			_playerHealthScript.HandsTakeDamage();
		}
	}
}
