using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;	
using UnityEngine.UI;



public class WinLoseTriggers : MonoBehaviour {

	[SerializeField] private SpawnNPCs _spawnEnemiesScript;
	[SerializeField] private SpawnNPCs _spawnCiviliansScript;
	private InitializeLevel _initializeLevel;
	public List<Transform> _enemyList = new List<Transform>();
	public List<Transform> _civilianList = new List<Transform>();
	public float _checkWinInterval;
	private float _lastCheckWinTime;
	private float _startTime;
	private bool _allEnemiesDead;
	private bool _allCiviliansDead;
	[SerializeField] private GameObject _endOfLevelText;
	private bool _stopCheckingForEnd;



	void Start () 
	{
		_startTime = Time.time;
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


			if (_stopCheckingForEnd == false)
			{
				if (_allEnemiesDead) 
				{
					_initializeLevel._levelNumber ++;
					_endOfLevelText.SetActive(true);
					_endOfLevelText.transform.GetComponentInChildren<Text>().text = "all enemies eliminated; \n loading next level...";
					Invoke("LoadNextLevel", 5);
					_stopCheckingForEnd = true;
				}

				if (_allCiviliansDead)
				{
					_initializeLevel._levelNumber = 0;
					_endOfLevelText.SetActive(true);
					_endOfLevelText.transform.GetComponentInChildren<Text>().text = "all friendlies eliminated; \n restarting...";
					Invoke("LoadNextLevel", 5);
					_stopCheckingForEnd = true;
				}	
			}
		}
	}

	private void LoadNextLevel ()
	{
		SceneManager.LoadScene("Continue");
	}

	public void AddToEnemyList (Transform _newEnemy)
	{
		_enemyList.Add(_newEnemy);
	}

	public void AddToCivilianList (Transform _newCivilian)
	{
		_civilianList.Add(_newCivilian);
	}

    public void PlayerDied()
    {
        _initializeLevel._levelNumber = 0;
        _endOfLevelText.SetActive(true);
        _endOfLevelText.transform.GetComponentInChildren<Text>().text = "you were shot to death; \n restarting...";
        Invoke("LoadNextLevel", 5);
        _stopCheckingForEnd = true;
    }

}
