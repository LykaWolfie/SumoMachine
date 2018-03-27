using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collide : MonoBehaviour {
	public event Action incrementScore;
	public float knockbackMultiplier = 4f;
	public float minimumKnockback = 10f;

	void Start(){
		knockbackMultiplier = 4f;
		minimumKnockback = 10f;
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Collectibles"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<CoinRotate>().triggerFlag();
            
           	if (incrementScore != null) {
				incrementScore ();
			}
        }
    }

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Player")) {
			Rigidbody rb = col.rigidbody;
			ScoreUpdater mySU = transform.parent.Find ("Coin Count").GetComponent<ScoreUpdater> ();
			ScoreUpdater otherSU = col.transform.parent.Find ("Coin Count").GetComponent<ScoreUpdater> ();

			float knockbackOnOther = Mathf.Clamp(otherSU.coinScore - mySU.coinScore, 0f, 10f) * knockbackMultiplier + minimumKnockback;
			rb.AddForce (-Vector3.Normalize(col.relativeVelocity) * knockbackOnOther, ForceMode.Impulse);
		}
	}
}
