﻿using UnityEngine;
using System.Collections;
using SilverAI.Core;


public class DetectDeath : MonoBehaviour {

	private SilverAI.Core.Health _healthComponent;
	private bool _checkHealth;
	private WinLoseTriggers _winLoseTriggersScript;


	void Start () {
		_healthComponent = GetComponent<SilverAI.Core.Health>();
		_checkHealth = true;
		_winLoseTriggersScript = GameObject.Find("Win Lose Triggers").GetComponent<WinLoseTriggers>();
	}
	

	void Update () {
	/*
		if (_healthComponent.health <= 0 && _checkHealth)				// this script is no longer used.  functionality moved to WinLoseTriggers
		{
			if (gameObject.tag == "Team1")
			{
				_winLoseTriggersScript.EnemyKilled();		
			}
			else if (gameObject.tag == "Team2")
			{
				_winLoseTriggersScript.CivilianKilled();
			}

			_checkHealth = false;

		}
		*/
	}
	/*
	void LateUpdate () {

		if (_healthComponent.alive == false && _checkHealth)
		{
			if (gameObject.tag == "Team1")
			{
				_winLoseTriggersScript.EnemyKilled();		
			}
			else if (gameObject.tag == "Team2")
			{
				_winLoseTriggersScript.CivilianKilled();
			}

			_checkHealth = false;
		}
	}
	*/
}
