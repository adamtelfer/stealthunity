using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("Collision detected with : " + other.gameObject.name);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
