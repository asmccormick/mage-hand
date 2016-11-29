using UnityEngine;
using System.Collections;
//
//	1) In your scene you should have controllers attached to the camera rig, eg:
//	[CameraRig]
//	-- Controller (Left)
//
//	2) Ensure that controller has both a "SteamVR_TrackedObject" script AND "SteamVR_TrackedController" script
//
//	3) Add this script to the controller, and modify it as necessary
//
[RequireComponent(typeof(SteamVR_TrackedController))]
public class ViveControlsExample : MonoBehaviour {

	private bool _leftController;
	[SerializeField] private SendDamage _sendDamageScript;
	[SerializeField] private AnimateRipple _animateRippleScript;


    void Start() {
		if (gameObject.name == "Controller (left)") {_leftController = true;}
    }

    // Use this for initialization
    void OnEnable () {
		SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();
		controller.TriggerClicked += OnClickTrigger;
		controller.TriggerUnclicked += OnUnclickTrigger;
		controller.PadClicked += OnPadClicked;
	}

	void OnDisable(){
		SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();
		controller.TriggerClicked -= OnClickTrigger;
		controller.TriggerUnclicked -= OnUnclickTrigger;
		controller.PadClicked -= OnPadClicked;
	}

	void OnPadClicked(object sender, ClickedEventArgs e)
	{
		Debug.Log ("Pad Clicked! X: " + e.padX + " " + e.padY);
	}


	void OnClickTrigger(object sender, ClickedEventArgs e) 
	{
		Debug.Log("Clicked trigger!");
		if (!_leftController)
		{
			_sendDamageScript.DamageTarget();
			_animateRippleScript.Burst();
		}
	}

	void OnUnclickTrigger(object sender, ClickedEventArgs e) 
	{
		Debug.Log("Unclicked trigger!");
	}

	void OnPadTouched(object sender, ClickedEventArgs e)
	{
		Debug.Log("pad touched: " + e.padX + " " + e.padY);
	}

}