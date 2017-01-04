using UnityEngine;
using System.Collections;

public class TriggerLens : MonoBehaviour {

	[SerializeField] private Renderer _lensRenderer;
	[SerializeField] private Renderer _rippleEffectRenderer;
	[SerializeField] private AnimateRipple _animateRipple;
	//[SerializeField] private Renderer _farHandRenderer;
	[SerializeField] private Renderer _nearHandRenderer;
	[SerializeField] private GameObject _distantHand;
	[SerializeField] private GameObject _nearHand;

	// Use this for initialization
	void Start () {
		_lensRenderer.enabled = false;
		//_rippleEffectRenderer.enabled = true;
		//_farHandRenderer.enabled = false;
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
			//_animateRipple.Burst();
			_nearHandRenderer.enabled = false;
			//_farHandRenderer.enabled = true;
			_distantHand.SetActive(true);
			_nearHand.SetActive(false);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Right Hand")
		{
			_lensRenderer.enabled = false;
			//_rippleEffectRenderer.enabled = false;
			_nearHandRenderer.enabled = true;
			//_farHandRenderer.enabled = false; 
			_distantHand.SetActive(false);
			_nearHand.SetActive(true);
		}
	}
}
