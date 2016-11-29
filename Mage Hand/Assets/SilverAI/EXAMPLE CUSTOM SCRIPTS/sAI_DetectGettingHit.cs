/*
	SAMPLE SCRIPT TO SHOW HOW TO
	DETECT WHEN A PLAYER OR AI IS RECEIVING DAMAGE

	For example, this will be useful if you want to display
	special effects when getting hit (such as flashing the screen red)

	This can be attached to any object with a Silver AI Health component.
	Even human player controllers can have this (as shown in our included third person demo)

	(C) 2013-2015 AIBotSystem.com

*/

using UnityEngine;
using System.Collections;
using SilverAI.Core;	// REQUIRED

public class sAI_DetectGettingHit : MonoBehaviour {

	// required reference
	private SilverAI.Core.Health healthComponent;



	void Start () {
		// get attached health component:
		healthComponent = GetComponent<SilverAI.Core.Health>();

		InvokeRepeating("checkIfReceivingDamage", 1f, 1f);
	}
	



	void checkIfReceivingDamage(){
		// use the health function:  checkIfReceivingDamage() which returns true / false

		if (healthComponent.checkIfReceivingDamage() == true){

			Debug.Log ("TOOK DAMAGE, damage amount = " + healthComponent.lastDamage);
			
		}
	}





	void Update () {
	
	}
}
