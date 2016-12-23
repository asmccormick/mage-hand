using UnityEngine;
using System.Collections;

public class WinLoseTriggers : MonoBehaviour {

	[SerializeField] private SpawnNPCs _spawnEnemiesScript;
	[SerializeField] private SpawnNPCs _spawnCiviliansScript;
	public int _totalEnemies;
	public int _totalCivilians;
	private InitializeLevel _initializeLevel;
	[SerializeField] private LoadLevel _loadLevel;

	// Use this for initialization
	void Start () {
		_totalEnemies = _spawnEnemiesScript.ReturnQty();
		_totalCivilians = _spawnCiviliansScript.ReturnQty();
		Debug.Log("enemies from wltrig = " + _totalEnemies);
		Debug.Log("civs from wltrig = " + _totalCivilians);
		_initializeLevel = GameObject.Find("Initialize Level").GetComponent<InitializeLevel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
}
