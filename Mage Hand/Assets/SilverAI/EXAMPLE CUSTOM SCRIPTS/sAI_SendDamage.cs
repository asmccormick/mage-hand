/*
	SAMPLE SCRIPT ON HOW TO SEND DAMAGE
	TO THE SILVER AI HEALTH COMPONENT

	USAGE: Attach to anything in your scene.
	Put the victim AI in the slot. Make sure it has a Health component attached.

	When you run the scene, it will damage the AI, 
	and if the damage is big enough, it should kill it.

	(C) 2014-2015 AIBotSystem.com

*/

using UnityEngine;
using System.Collections;
using SilverAI.Core;

public class sAI_SendDamage : MonoBehaviour {

	public GameObject theVictim;

	// Use this for initialization
	void Start () {
		
		// immediately send damage on start:
		if (theVictim != null){
			if(theVictim.GetComponent<SilverAI.Core.Health>() != null){

				// send damage (200 damage, which will auto kill most AI on start):
				theVictim.GetComponent<SilverAI.Core.Health>().takeDamage(200f);
				
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
