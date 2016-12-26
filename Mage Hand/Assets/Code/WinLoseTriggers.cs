using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;	
using UnityEngine.UI;



public class WinLoseTriggers : MonoBehaviour {

	[SerializeField] private SpawnNPCs _spawnEnemiesScript;
	[SerializeField] private SpawnNPCs _spawnCiviliansScript;
	public int _totalEnemies;
	public int _totalCivilians;
	private InitializeLevel _initializeLevel;
	[SerializeField] private LoadLevel _loadLevel;
	public List<Transform> _enemyList = new List<Transform>();
	public List<Transform> _civilianList = new List<Transform>();
	public float _checkWinInterval;
	private float _lastCheckWinTime;
	private float _startTime;
	private bool _allEnemiesDead;
	private bool _allCiviliansDead;
	[SerializeField] private GameObject _endOfLevelText;



	void Start () 
	{
		_startTime = Time.time;
		_totalEnemies = _spawnEnemiesScript.ReturnQty();
		_totalCivilians = _spawnCiviliansScript.ReturnQty();
		Debug.Log("enemies from wltrig = " + _totalEnemies);
		Debug.Log("civs from wltrig = " + _totalCivilians);
		_initializeLevel = GameObject.Find("Initialize Level").GetComponent<InitializeLevel>();
		_endOfLevelText.SetActive(false);
	}
	

	void Update () 
	{
		if (Time.time > _startTime + 10 && Time.time > _checkWinInterval + _lastCheckWinTime)
		{
			_lastCheckWinTime = Time.time;
			for (int i = 0; i < _enemyList.Count; i++)
			{
				if (_enemyList[i] == null)
				{
					_allEnemiesDead = true;
				} else {
					_allEnemiesDead = false;
					break;
				}
			}

			for (int j = 0; j < _civilianList.Count; j++)
			{
				if (_civilianList[j] == null)
				{
					_allCiviliansDead = true;
				} else {
					_allCiviliansDead = false;
					break;
				}
			}

			if (_allEnemiesDead) 
			{
				_initializeLevel._levelNumber ++;
				_endOfLevelText.SetActive(true);
				_endOfLevelText.transform.GetComponentInChildren<Text>().text = "all enemies eliminated; \n loading next level...";
				//SceneManager.LoadScene("Continue");
				Invoke("LoadNextLevel", 5);
			}

			if (_allCiviliansDead)
			{
				_initializeLevel._levelNumber = 0;
				_endOfLevelText.SetActive(true);
				_endOfLevelText.transform.GetComponentInChildren<Text>().text = "all friendlies eliminated; \n restarting...";
				//SceneManager.LoadScene("Continue");
				Invoke("LoadNextLevel", 5);
			}
		}
	}

	private void LoadNextLevel ()
	{
		SceneManager.LoadScene("Continue");
	}

	/*
	public void EnemyKilled ()
	{
		Debug.Log("EnemyKilled() called in WinLoseTriggers.cs");
		_totalEnemies--;
		CheckWinLose();
	}

	public void CivilianKilled ()
	{
		Debug.Log("CivilianKilled() called in WinLoseTriggers.cs");
		_totalCivilians--;
		CheckWinLose();
	}

	private void CheckWinLose ()
	{
		if (_totalEnemies <= 0)
		{
			Debug.Log("YOU WIN!  All enemies eliminated.");
			_initializeLevel._levelNumber ++;
			_loadLevel.PlayerWon();
		}
		else if (_totalCivilians <= 0)
		{
			Debug.Log("YOU LOSE!  All civilians eliminated.");
			_initializeLevel._levelNumber = 0;
			_loadLevel.PlayerLost();
		}
	}
	*/

	public void AddToEnemyList (Transform _newEnemy)
	{
		_enemyList.Add(_newEnemy);
	}

	public void AddToCivilianList (Transform _newCivilian)
	{
		_civilianList.Add(_newCivilian);
	}

}
