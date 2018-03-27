using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour {
    private int points=0;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(points);
        if (other.gameObject.CompareTag("Collectibles"))
        {
            Destroy(other.gameObject);
            Spawner.time = 0;
            points++;
        }
    }
}
