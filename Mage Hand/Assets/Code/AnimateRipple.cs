using UnityEngine;
using System.Collections;

public class AnimateRipple : MonoBehaviour {

	private Renderer _renderer;
	private float _bumpAmount;
	private float _burstStartTime;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_bumpAmount > 0)
		{
			float _elapsedTime = Time.time - _burstStartTime;
			_bumpAmount = 128 - (_elapsedTime * 50);
		} else {
			_bumpAmount = 0;
		}
		_renderer.material.SetFloat("_BumpAmt", _bumpAmount);
	}

	public void Burst()
	{
		_bumpAmount = 128;
		_burstStartTime = Time.time;
	}
}
