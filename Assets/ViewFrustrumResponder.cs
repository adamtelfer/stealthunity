using UnityEngine;
using System.Collections;

public class ViewFrustrumResponder : MonoBehaviour {

	public GameObject responder;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter ( Collider other ) {
		Debug.Log ("View Trigger");
	}

	void OnTriggerExit ( Collider other ) {
		Debug.Log ("View Trigger Exit");
	}

	void OnCollisionEnter ( Collision other ) {
		Debug.Log ("View Collision");
	}
}
