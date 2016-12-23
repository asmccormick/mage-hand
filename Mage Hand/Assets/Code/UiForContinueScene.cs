using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiForContinueScene : MonoBehaviour {

	private InitializeLevel _initializeLevel;
	private Text _levelText;

	// Use this for initialization
	void Start () {
		_initializeLevel = GameObject.Find("Initialize Level").GetComponent<InitializeLevel>();
		_levelText = transform.GetComponent<Text>();
		int _levelNumber = _initializeLevel._levelNumber + 1;
		_levelText.text = "Level " + _levelNumber + " of 5";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
