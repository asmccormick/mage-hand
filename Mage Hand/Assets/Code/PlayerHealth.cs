using UnityEngine;
using System.Collections;
using SilverAI.Core;


public class PlayerHealth : MonoBehaviour {

	[SerializeField] private float _maxHealth;
	private float _currentHealth;
	[SerializeField] private Renderer _circleOfPainRenderer;
	[SerializeField] private float _painDecayRate;
	private SilverAI.Core.Health _healthComponent;
	[SerializeField] private float _regenerateRate;


	// Use this for initialization
	void Start () {
		_healthComponent = GetComponent<SilverAI.Core.Health>();
		_healthComponent.resetHealth(_maxHealth);
		_healthComponent.resetHealthRegen(_regenerateRate);
		//InvokeRepeating("checkIfReceivingDamage", 0.1f, 0.1f);
		InvokeRepeating("checkPlayerHealth", 0.1f, 0.1f);

	}
	
	// Update is called once per frame
	void Update () {
		//checkIfReceivingDamage ();
		AnimateCircleOfPain();
		//Debug.Log("current pain = " + _currentPain);

	}

	private void AnimateCircleOfPain ()
	{
		if (_healthComponent.health < 100)
		{
			_currentPain -= _painDecayRate;
			float _tempAlpha = _currentPain / 100;
			Color _tempColor = new Color(_circleOfPainRenderer.material.color.r, _circleOfPainRenderer.material.color.g, _circleOfPainRenderer.material.color.b, _tempAlpha);
			_circleOfPainRenderer.material.color = _tempColor;
		}
	}

	/*
	void OnCollisionEnter (Collision collision)
	{
		Debug.Log("player health collision = " + collision.gameObject.name);

	}
	*/

	void checkIfReceivingDamage ()
	{
		if (_healthComponent.checkIfReceivingDamage() == true)
		{
			Debug.Log ("TOOK DAMAGE, damage amount = " + _healthComponent.lastDamage);
			_currentPain += _healthComponent.lastDamage;
		}
	}

	void checkPlayerHealth ()
	{
		float _health = _healthComponent.health;
		Debug.Log("health = " + _health);
		if (_health < 100)
	}
}
