using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] private float _maxHealth;
	private float _currentHealth;
	[SerializeField] private Renderer _circleOfPainRenderer;
	[SerializeField] private float _painDecayRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AnimateCircleOfPain();
	}

	private void AnimateCircleOfPain ()
	{

		Debug.Log("pain alpha = " + _circleOfPainRenderer.material.color.a);
		if (_circleOfPainRenderer.material.color.a > 0)
		{
			float _tempAlpha = _circleOfPainRenderer.material.color.a - _painDecayRate;
			Color _tempColor = new Color(_circleOfPainRenderer.material.color.r, _circleOfPainRenderer.material.color.g, _circleOfPainRenderer.material.color.b, _tempAlpha);
			_circleOfPainRenderer.material.color = _tempColor;
		}
	}
}
