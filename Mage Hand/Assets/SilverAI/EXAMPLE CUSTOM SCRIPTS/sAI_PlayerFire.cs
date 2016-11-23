/*
	SAMPLE SCRIPT TO SHOW
	HOW TO SPAWN A BULLET AND SHOOT IT

	ATTACH THIS TO A HUMAN PLAYER CONTROLLER
	AND USE LEFT MOUSE TO SHOOT

	Note: the object pool is automatically filled out at run time...

	(C) 2014-2015 AIBotSystem.com

*/

using UnityEngine;
using System.Collections;

public class sAI_PlayerFire : MonoBehaviour {

	public GameObject shootPosition;
	public GameObject bulletToFire;
	private float currentBulletSpeed = 0; // this is retrieved from the bullet itself...under PROJECTILE component

	private GameObject objectPooler;


	// Use this for initialization
	void Start () {

		// check if there is an object pool in the scene:
		// NOTE: MAKE SURE THE OBJECT POOL AS THE CORRECT OBJECTS LOADED IN THE SLOTS!
		// If a bullet is not placed in the object pool loading slot, the bullet will not be
		// spawned in the game (so it will look like you or the AI are not shooting anything)


		if (objectPooler == null){
			objectPooler = GameObject.Find("Object Pool");
			if ((objectPooler == null) || (objectPooler.GetComponent<SilverAI.Core.ObjectPool>() == null)) {
				Debug.Log("Missing Object Pool! You need a blank gameobject named Object Pool, with the Object Pool system attached!");
				
			}
		}


		// get the bullet's speed:
		// remember, each bullet requires a Projectile component
		if (bulletToFire != null){
	 		if (bulletToFire.GetComponent<SilverAI.Core.Projectile>() != null){
	 			currentBulletSpeed = bulletToFire.GetComponent<SilverAI.Core.Projectile>().bulletSpeed;
	 		}			
		}		

	
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetButton("Fire1")){

	    	GameObject BulletPrefab; // this will hold the spawned bullet...
	       
			// grab a projectile from the weapon pool:
			// check if an object pool exists:
				if ((objectPooler == null) || (objectPooler.GetComponent<SilverAI.Core.ObjectPool>() == null)) {
					return;
				} else {

					// check if the bullet slot is filled out:
					if (bulletToFire != null){

						// [IMPORTANT FUNCTION] retrieve from object pool (and put it in variable BulletPrefab):
						BulletPrefab = objectPooler.GetComponent<SilverAI.Core.ObjectPool>().retrieveObject(bulletToFire);		
					} else {
						BulletPrefab = null;
					}
					
				}



				// check if we properly retrieved an object from the pool:
				if (BulletPrefab != null){
					
					// reset the spawned bullet's position:
					BulletPrefab.transform.position = shootPosition.transform.position;
					BulletPrefab.transform.rotation = shootPosition.transform.rotation;

			     	Rigidbody bulletrb = BulletPrefab.GetComponent<Rigidbody>();
			     	
			     	
			     	// fire / add force (make sure bullet has a Rigidbody!):
			     	bulletrb.AddForce(transform.forward * currentBulletSpeed);			
				}





		 }
	}


}
