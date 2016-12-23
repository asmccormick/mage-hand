using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNPCs : MonoBehaviour {

	//[SerializeField] private Transform _npcPrefab;
	[SerializeField] private bool _typeIsCivilians;
	[SerializeField] private Transform _spawnEffect;
	private int _qtyToSpawn;
	private int _qtySpawned;
	private int _spawnRange = 35;
	private Vector3 _newSpawnPos;
	[SerializeField] private float _timeBetweenSpawns;
	private float _lastSpawnTime;
	private bool _shouldSpawn;
	private RaycastHit _hit;
	//[SerializeField] private int _initialSpawn;
	//[SerializeField] private bool _spawnFromPortal;
	[SerializeField] private float _delayBeforeSpawning;
	[SerializeField] private List<Transform> _prefabList = new List<Transform>();
	private InitializeLevel _initializeLevel;

	// Use this for initialization
	void Start () {
		_initializeLevel = GameObject.Find("Initialize Level").GetComponent<InitializeLevel>();
		Debug.Log("init level = " + _initializeLevel);
		if (_typeIsCivilians)
		{
			_qtyToSpawn = _initializeLevel._qtyCivilians[_initializeLevel._levelNumber];
		} else {
			_qtyToSpawn = _initializeLevel._qtyEnemies[_initializeLevel._levelNumber];
		}
	}

	// Update is called once per frame
	void Update () {
		if (_qtySpawned < _qtyToSpawn && _shouldSpawn)
		{
			GenerateNewSpawnPosition();
			RaycastToGround();
		}
		else if (_shouldSpawn == false && Time.time > _lastSpawnTime + _timeBetweenSpawns && Time.time > _delayBeforeSpawning)
		{
			_shouldSpawn = true;
		}
	}

	/*
	public void InitialSpawn ()
	{
		for (int i = 0; i < _initialSpawn; i++) 
		{
			GenerateNewSpawnPosition();
			RaycastToGround();
		}
	}
	*/

	private void RaycastToGround ()
	{
		Debug.DrawRay(_newSpawnPos, Vector3.down * 200, Color.white, 1);
		if (Physics.Raycast(_newSpawnPos, Vector3.down, out _hit))
		{
			if (_hit.transform.name == "Ground Central")
			{
				Instantiate(_prefabList[Random.Range(0,_prefabList.Count)], _hit.point, Quaternion.identity);
				if (_spawnEffect) {Instantiate(_spawnEffect, _hit.point, Quaternion.identity);}
				_qtySpawned++;
				_lastSpawnTime = Time.time;
				_shouldSpawn = false;
			}
		}
	}

	private void GenerateNewSpawnPosition ()
	{
		_newSpawnPos.x = Random.Range(-_spawnRange,_spawnRange);
		_newSpawnPos.y = 20;
		_newSpawnPos.z = Random.Range(-_spawnRange,_spawnRange);	
	}

	public int ReturnQty ()
	{
		return _qtyToSpawn;
	}

	public void SetQtyToSpawn (int n)
	{
		_qtyToSpawn = n;
	}
}
