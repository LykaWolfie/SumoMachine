using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public float botDistance = 1.5f;

	void Update () {
		if (player != null) {
			transform.position = player.position + Vector3.back * botDistance;	
		}
	}
}
