using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;	

public class LoadLevel : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadALevel ()
	{
		// fade to black or some other effect



	}

	public void PlayerLost()
	{
		SceneManager.LoadScene("Continue");
	}

	public void PlayerWon ()
	{
		SceneManager.LoadScene("Continue");
	}

	public void LoadLevelFromUi (string _sceneName)
	{
		SceneManager.LoadScene(_sceneName);
	}
}
