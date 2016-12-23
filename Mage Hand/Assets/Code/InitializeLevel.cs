using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;	


public class InitializeLevel : MonoBehaviour {

	public int _levelNumber = 0;
	public List<int> _qtyCivilians = new List<int>();
	public List<int> _qtyEnemies = new List<int>();
	//[SerializeField] private SpawnNPCs _spawnEnemiesScript;
	//[SerializeField] private SpawnNPCs _spawnCiviliansScript;


	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		SceneManager.LoadScene("Continue");
	}

	// Use this for initialization
	void Start () 
	{
		


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
