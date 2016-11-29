using UnityEngine;
using System.Collections;

public class SpawnNPCs : MonoBehaviour {

	[SerializeField] private Transform _npcPrefab;
	[SerializeField] private Transform _spawnParticleSystem;
	[SerializeField] private int _qtyToSpawn;
	private int _qtySpawned;
	[SerializeField] private int _spawnRange;
	private Vector3 _newSpawnPos;
	[SerializeField] private float _timeBetweenSpawns;
	private float _lastSpawnTime;
	private bool _shouldSpawn;
	private RaycastHit _hit;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (_qtySpawned < _qtyToSpawn && _shouldSpawn)
		{
			GenerateNewSpawnPosition();
			RaycastToGround();
		}
		else if (_shouldSpawn == false && Time.time > _lastSpawnTime + _timeBetweenSpawns)
		{
			_shouldSpawn = true;
		}
	}

	private void RaycastToGround ()
	{
		Debug.DrawRay(_newSpawnPos, Vector3.down * 200, Color.white, 1);
		if (Physics.Raycast(_newSpawnPos, Vector3.down, out _hit))
		{
			if (_hit.transform.name == "Ground Central")
			{
				Instantiate(_npcPrefab, _hit.point, Quaternion.identity);
				_qtySpawned++;
				_lastSpawnTime = Time.time;
				_shouldSpawn = false;
			}
		}
	}

	private void GenerateNewSpawnPosition ()
	{
		_newSpawnPos.x = Random.Range(-_spawnRange,_spawnRange);
		_newSpawnPos.y = 100;
		_newSpawnPos.z = Random.Range(-_spawnRange,_spawnRange);
	}

	public int ReturnQty ()
	{
		return _qtyToSpawn;
	}
}
