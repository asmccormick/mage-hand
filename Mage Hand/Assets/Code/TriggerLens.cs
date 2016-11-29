using UnityEngine;
using System.Collections;

public class TriggerLens : MonoBehaviour {

	[SerializeField] private Renderer _lensRenderer;
	[SerializeField] private Renderer _rippleEffectRenderer;
	[SerializeField] private AnimateRipple _animateRipple;

	// Use this for initialization
	void Start () {
		_lensRenderer.enabled = false;
		_rippleEffectRenderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Right Hand")
		{
			_lensRenderer.enabled = true;
			//_rippleEffectRenderer.enabled = true;
			_animateRipple.Burst();
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Right Hand")
		{
			_lensRenderer.enabled = false;
			//_rippleEffectRenderer.enabled = false;
		}
	}
}
