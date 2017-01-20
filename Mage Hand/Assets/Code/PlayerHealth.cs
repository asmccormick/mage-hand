using UnityEngine;
using System.Collections;
using SilverAI.Core;
using UnityEngine.SceneManagement;	


public class PlayerHealth : MonoBehaviour {

	[SerializeField] private float _maxHealth;
	private float _currentHealth;
	[SerializeField] private Renderer _circleOfPainRenderer;
	private SilverAI.Core.Health _healthComponent;
	[SerializeField] private float _regenerateRate;
    private WinLoseTriggers _winLoseTriggersScript;
	[SerializeField] private bool _godMode;


	void Start () 
	{
		_healthComponent = GetComponent<SilverAI.Core.Health>();
		if (_healthComponent == null) {Debug.Log("CANNOT FIND HEALTH COMPONENT.  Ensure that health script is attached to Player Target game object, but is disabled.");}
		_healthComponent.resetHealth(_maxHealth);
        _winLoseTriggersScript = GameObject.Find("Win Lose Triggers").GetComponent<WinLoseTriggers>();
		_healthComponent.godMode = _godMode;
	}
	

	void Update () 
	{
		if (_healthComponent)		// health is only used in the gameplay scenes, not other menus
		{
			if (_healthComponent.health < _maxHealth) {_healthComponent.health += _regenerateRate * Time.deltaTime;}
			AnimateCircleOfPain();
			if (_healthComponent.alive == false) { _winLoseTriggersScript.PlayerDied();}
		}
	}

	private void AnimateCircleOfPain ()
	{
		float _tempAlpha = (_maxHealth - _healthComponent.health) / _maxHealth;
		Color _tempColor = new Color(_circleOfPainRenderer.material.color.r, _circleOfPainRenderer.material.color.g, _circleOfPainRenderer.material.color.b, _tempAlpha);
		_circleOfPainRenderer.material.color = _tempColor;
	}

	public void HandsTakeDamage ()
	{
		_healthComponent.takeDamage(50);
	}
}
