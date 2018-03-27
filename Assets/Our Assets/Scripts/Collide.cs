using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collide : MonoBehaviour {
	public event Action incrementScore;
    //private int points = 0;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(points);
        if (other.gameObject.CompareTag("Collectibles"))
        {
            Destroy(other.gameObject);
            Spawner.time = 0;
            //points++;
			if (incrementScore != null) {
				incrementScore ();
			}
        }
    }
}
