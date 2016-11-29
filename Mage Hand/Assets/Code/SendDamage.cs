using UnityEngine;
using System.Collections;
using SilverAI.Core;


public class SendDamage : MonoBehaviour {

	private GameObject _target;

	public void SetTarget(GameObject _thisTarget)
	{
		_target = _thisTarget;
	}

	public void DamageTarget()
	{
		if (_target != null){
			if(_target.GetComponent<SilverAI.Core.Health>() != null){
				_target.GetComponent<SilverAI.Core.Health>().takeDamage(200f);
			}
		}
	}
}
