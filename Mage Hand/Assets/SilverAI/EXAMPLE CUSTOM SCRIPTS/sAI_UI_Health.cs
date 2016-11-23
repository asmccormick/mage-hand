using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using SilverAI.Core;	// REQUIRED

public class sAI_UI_Health : MonoBehaviour {

	public SilverAI.Core.Health healthComponent;
	private Text healthLabel;

	// Use this for initialization
	void Start () {
		healthLabel = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float healthPerc = healthComponent.getHealthPercentage();
		healthLabel.text = "HEALTH: " + healthPerc + "%";
	}
}
