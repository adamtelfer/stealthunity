using UnityEngine;
using System.Collections;

public class ViewFrustrumResponder : MonoBehaviour {

	public GameObject responder;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D ( Collider2D other ) {
		Debug.Log ("OnTriggerEnter " + other.name + " " + other.tag);

		if (other.tag == "EnemySoundFrustrum") {

		}
	}

	void OnTriggerExit2D ( Collider2D other ) {
		Debug.Log ("OnTriggerExit " + other.name + " " + other.tag);
	}

	void OnCollisionEnter2D ( Collision2D other ) {
		Debug.Log ("OnCollisionEnter " + other.collider.name + " " + other.collider.tag);
	}
}
