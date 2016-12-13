using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;	


public class UiButton : MonoBehaviour {

	[SerializeField] bool _loadLevel;
	[SerializeField] string _levelName;
	private LoadLevel _loadLevelScript;

	// Use this for initialization
	void Start () {
		_loadLevelScript = GameObject.Find("LoadLevel").GetComponent<LoadLevel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick ()
	{
		if (_loadLevel)
		{
			//SceneManager.LoadScene(_levelName);
			_loadLevelScript.LoadLevelFromUi(_levelName);
		}
	}
}
