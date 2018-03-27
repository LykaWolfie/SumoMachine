using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FallingDown : MonoBehaviour {

	public event Action resetScore;

    public float height = -10f;
    private Vector3 originalPos;
    private Quaternion originalRot;


    /*   public float spawnAntiGravity = 20f;

  
       private bool spawnGrav;
       Rigidbody rb;
       void Start () {
           originalPos = transform.position;
           originalRot = transform.rotation;
           spawnGrav = false;
       }


       void FixedUpdate () {
           if (transform.position.y <= height)
           {
               transform.SetPositionAndRotation(originalPos + new Vector3(0,5,0),originalRot);
               rb.isKinematic = true;
               spawnGrav = true;
           }
           if (spawnGrav)
           {
               rb.AddForce(Vector3.up * spawnAntiGravity, ForceMode.Acceleration);
           }
           if (transform.position.y == 1)
           {
               spawnGrav = false;
           }
           Debug.Log(spawnGrav);
           Debug.Log(rb.isKinematic);
       }*/
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;

    }
    void Update()
    {
        if  (transform.position.y <= height)
        {
            transform.SetPositionAndRotation(originalPos, originalRot);
			if (resetScore != null) {
				resetScore ();
			}
		}
    }
}
