using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class InitializeLevel : MonoBehaviour {

	public int _levelNumber;
	[SerializeField] private List<int> _qtyCivilians = new List<int>();
	[SerializeField] private List<int> _qtyEnemies = new List<int>();
	[SerializeField] private SpawnNPCs _spawnEnemiesScript;
	[SerializeField] private SpawnNPCs _spawnCiviliansScript;

	// Use this for initialization
	void Start () 
	{
		_spawnEnemiesScript.SetQtyToSpawn(_qtyEnemies[_levelNumber]);
		_spawnCiviliansScript.SetQtyToSpawn(_qtyCivilians[_levelNumber]);
		//_spawnCiviliansScript.InitialSpawn();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
