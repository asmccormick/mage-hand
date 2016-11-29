using UnityEngine;
using System.Collections;

public class AnimateRipple : MonoBehaviour {

	private Renderer _renderer;
	private float _bumpAmount;
	private float _burstStartTime;
	[SerializeField] private Transform _rightController;
	[SerializeField] private Transform _cameraEyes;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
		_renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (_bumpAmount > 0)
		{
			if (_renderer.enabled == false) {_renderer.enabled = true;}
			float _elapsedTime = Time.time - _burstStartTime;
			_bumpAmount = 128 - (_elapsedTime * 200);
		} else {
			_bumpAmount = 0;
			_renderer.enabled = false;
		}
		_renderer.material.SetFloat("_BumpAmt", _bumpAmount);
	}

	public void Burst()
	{
		_bumpAmount = 128;
		_burstStartTime = Time.time;
		_renderer.enabled = true;
		transform.parent.position = _rightController.position;
		transform.parent.LookAt(_cameraEyes);
	}
}
