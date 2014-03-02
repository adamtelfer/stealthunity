using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D ( Collider2D other ) {
		Debug.Log ("OnTriggerEnter " + other.name + " " + other.tag);
		
		if (other.tag == "EnemySoundFrustrum") {
			
		} else if (other.tag == "EnemyViewFrustrum") {
			GameManager.SharedManager.LostALife();
		}
	}
	
	void OnTriggerExit2D ( Collider2D other ) {
		Debug.Log ("OnTriggerExit " + other.name + " " + other.tag);

		if (other.tag == "EnemySoundFrustrum") {
			
		} else if (other.tag == "EnemyViewFrustrum") {
			
		}
	}

	void OnCollisionEnter2D ( Collision2D other ) {

	}
}
