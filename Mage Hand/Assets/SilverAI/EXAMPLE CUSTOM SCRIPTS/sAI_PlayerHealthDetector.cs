/*
	SAMPLE SCRIPT TO SHOW HOW TO
	RETRIEVE DATA FROM THE SILVER A.I. HEALTH COMPONENT

	remember, the Silver AI Health module can also be attached
	to human player controllers (as we did in the included third person demo)

	(C) 2014-2015 www.AIBotSystem.com

*/


using UnityEngine;
using System.Collections;
using SilverAI.Core;	// REQUIRED

using UnityEngine.SceneManagement;	// for reloading the scene. new API for Unity 5.3+


public class sAI_PlayerHealthDetector : MonoBehaviour {

	// required reference
	private SilverAI.Core.Health healthComponent;

	// vars for storing data:
	[SerializeField]
	private float health;	// this variable is not used, but is here to
							// show how you can retrieve the Health from the AI Health component
							// with an external script
							// basically, you can grab the health like this:
							// float health = GetComponent<SilverAI.Core.Health>().health
							// ( as shown below )

	[SerializeField]
	private float percentageHealth;
							// this variable is not used
							// but shows how you can get the percentage of
							// health left (0 - 100%), through the AI Health Component:
							// float healthPerc = GetComponent<SilverAI.Core.Health>().getHealthPercentage();
							// returns 0 - 100


	void Start () {
		// get attached health component:
		healthComponent = GetComponent<SilverAI.Core.Health>();

		// set custom health at run time:
		healthComponent.resetHealth(500f);	// resets health to 500, and fully heals

		// check health every 0.1 seconds:
		InvokeRepeating("checkPlayerHealth", 0.1f, 0.1f);
	}
	

	void checkPlayerHealth(){

		// get some stats:
			// get player health:
			health = healthComponent.health;

			// get remaining health percentage:
			percentageHealth = healthComponent.getHealthPercentage();	// returns float from 0 - 100


		// you can also check if this player is still alive:
		// NOTE: this is the recommended way to check if this player is alive, 
		// rather than testing if health > 0
		if (healthComponent.alive == false){
			// if health falls below 0, restart the game:
			// Application.LoadLevel(Application.loadedLevel);	// reload scene, pre-Unity 5.3
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);	// Unity 5.3 new api
		}

	}


	void Update () {
		// alternatively, you can check health stats in here as well,
		// but unless your health is constantly changing,
		// put the function in a timer or coroutine instead
		// for performance reasons.
	}
}
