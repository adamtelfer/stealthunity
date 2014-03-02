using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static string PlayerIdleState = "PlayerIdle";
	public static string PlayerMoveState = "PlayerWalk";

	public PlayerControlComponent controlComponent;

	public Animator playerSpriteAnimator;


	// Movement Controller

	private Vector3 currentTarget;
	public int currentFingerIndex;
	public float baseSpeed;
	public float maxSpeed;


	public void SetTarget ( Vector3 target, FingerGestures.Finger f) {
		playerSpriteAnimator.Play(PlayerMoveState);

	}

	void MoveUpdate() {

	}

	void StopMovement () {
		playerSpriteAnimator.Play (PlayerIdleState);
		currentTarget = transform.position;
		rigidbody2D.velocity = Vector3.zero;
	}

    // Collision Controls
	void OnTriggerEnter2D ( Collider2D other ) {
		Debug.Log ("OnTriggerEnter " + other.name + " " + other.tag);
		
		if (other.tag == "EnemySoundFrustrum") {
			
		} else if (other.tag == "EnemyViewFrustrum") {

		}
	}
	
	void OnTriggerExit2D ( Collider2D other ) {
		Debug.Log ("OnTriggerExit " + other.name + " " + other.tag);
	}
	
	void OnCollisionEnter2D ( Collision2D other ) {
		if (other.collider.tag == "EnemyCollider") {
			GameManager.SharedManager.LostALife();
		}
	}

	// Spawn Points

	public void DieAndGoToSpawnPoint (SpawnPoint spawnPoint) {
		this.transform.position = spawnPoint.transform.position;
	}


	// Use this for initialization
	void Start () {
		playerSpriteAnimator.Play (PlayerIdleState);
		playerSpriteAnimator.speed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		MoveUpdate ();
	}
}
