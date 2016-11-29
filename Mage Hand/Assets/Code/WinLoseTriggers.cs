using UnityEngine;
using System.Collections;

public class WinLoseTriggers : MonoBehaviour {

	[SerializeField] private SpawnNPCs _spawnEnemiesScript;
	[SerializeField] private SpawnNPCs _spawnCiviliansScript;
	private int _totalEnemies;
	private int _totalCivilians;

	// Use this for initialization
	void Start () {
		_totalEnemies = _spawnEnemiesScript.ReturnQty();
		_totalCivilians = _spawnCiviliansScript.ReturnQty();
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
		}
		else if (_totalCivilians <= 0)
		{
			Debug.Log("YOU LOSE!  All civilians eliminated.");
		}
	}
}
