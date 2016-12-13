using UnityEngine;
using System.Collections;

public class LookAtHand : MonoBehaviour {

	//[SerializeField] private Transform _rightController;
	[SerializeField] private Transform _distantHand;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(_distantHand);
	}
}
