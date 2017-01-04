using UnityEngine;
using System.Collections;
using SilverAI.Core;


public class SendDamage : MonoBehaviour {

	private GameObject _target;
	private bool _canDamage;
	private float _disableDamageTime;
	private Renderer _handRenderer;
	[SerializeField] private AnimateRipple _animateRippleScript;
	[SerializeField] private VibrateController _vibrateControllers;
	[SerializeField] private AudioSource _frameAudioSource;

	private GameObject _activatedHand;
	private GameObject _deactivatedHand;


	void Start ()
	{
		//_handRenderer = GetComponent<Renderer>();
		//_handRenderer.material.color = Color.green;
		_canDamage = true;
		_activatedHand = transform.FindChild("Activated Hand").gameObject;
		_deactivatedHand = transform.FindChild("Deactivated Hand").gameObject;
		_deactivatedHand.SetActive(false);
	}

	public void SetTarget(GameObject _thisTarget)
	{
		_target = _thisTarget;
	}

	public void DamageTarget()
	{
		if (_target != null && _canDamage)
		{
			if(_target.GetComponent<SilverAI.Core.Health>() != null)
			{
				_target.GetComponent<SilverAI.Core.Health>().takeDamage(200f);
			}

			if (_target.tag == "UI")
			{
				_target.GetComponent<UiButton>().OnClick();
			}

			if (_target.tag == "Nest Teleporter")
			{
				_target.GetComponent<NestTeleporter>().TeleportHere();
			}

			_canDamage = false;
			//_handRenderer.material.color = Color.red;
			_animateRippleScript.Burst();
			_vibrateControllers.VibrateForDamage();
			_frameAudioSource.Play();
			_activatedHand.SetActive(false);
			_deactivatedHand.SetActive(true);
			Invoke ("ReenableDamageAbility", 2);
		}
	}

	private void ReenableDamageAbility ()
	{
		_canDamage = true;
		//_handRenderer.material.color = Color.green;
		_activatedHand.SetActive(true);
		_deactivatedHand.SetActive(false);
		_vibrateControllers.VibrateForFiring();
	}
}
