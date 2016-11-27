using UnityEngine;
using System.Collections;

public class DeleteSelf : MonoBehaviour {

	[SerializeField] private float _timeToDelete;

	// Use this for initialization
	void Start () {
		Invoke("Delete", _timeToDelete);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Delete ()
	{
		Destroy(gameObject);
	}
}
