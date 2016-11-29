using UnityEngine;
using System.Collections;

public class RaycastFromLens : MonoBehaviour {

	[SerializeField] private Transform _distantHand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Raycast();
	}

	public void Raycast() {
		Vector3 _fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit _hit;
		Debug.DrawRay(transform.position, _fwd * 100, Color.green, 1);
		if (Physics.Raycast(transform.position, _fwd, out _hit)) {
			{
				_distantHand.position = _hit.point;
			}
		}
	}
}
