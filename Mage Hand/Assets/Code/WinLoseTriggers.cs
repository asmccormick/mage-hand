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
}
