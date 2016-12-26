using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	[SerializeField] private float _speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.up * _speed);
	}
}
