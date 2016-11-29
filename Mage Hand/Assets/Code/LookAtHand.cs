using UnityEngine;
using System.Collections;

public class LookAtHand : MonoBehaviour {

	[SerializeField] private Transform _rightController;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(_rightController);
	}
}
