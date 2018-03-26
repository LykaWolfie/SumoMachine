using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

	public float maxSpinSpeed = 500;		//default max rotation speed
	public float minSpinSpeed = 200;		//default min rotation speed
	[HideInInspector]
	public float spinSpeed;					//rotation speed that we will edit
	public float spindeceleration = 300; 	//deceleration of spin when pressed

	private bool isChargingUp;				//will stay true while button is being pressed
	private int clockwiseMultiplier; 		// = 1 when spinning clockwise; = -1 when spinning counterclockwise


	void Start () {
		spinSpeed = maxSpinSpeed;
		isChargingUp = false;
		clockwiseMultiplier = 1;			//initially spinning clockwise
	}
	
	void Update(){
		transform.Rotate(Vector3.up * spinSpeed * clockwiseMultiplier * Time.deltaTime);	//rotate the player
		if (isChargingUp) {																	//will slowdown the spin every frame if button is being pressed
			spinSpeed = Mathf.Clamp (spinSpeed - spindeceleration * Time.deltaTime, minSpinSpeed, maxSpinSpeed); //clamps decelerated speed between min and max spin speeds
		}
	}

	public void reactToButtonPress(){
		isChargingUp = true;				//trigger chargingUp switch and deceleration to happen every Update
	}

	public void reactToButtonRelease(){
		isChargingUp = false;
		spinSpeed = maxSpinSpeed;			//reset the spin to maximum default
		clockwiseMultiplier = -clockwiseMultiplier; //change from clockwise to counter clockwise or vice versa
	}
}
