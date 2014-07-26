using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static string PlayerIdleState = "PlayerIdle";
	public static string PlayerMoveState = "PlayerWalk";

	public PlayerControlComponent controlComponent;
    public MovementComponent movementComponent;
    public SpriteUpdaterComponent spriteUpdaterComponent;

    // Collision Controls
	void OnTriggerEnter2D ( Collider2D other ) {
		Debug.Log ("OnTriggerEnter " + other.name + " " + other.tag);
		if (other.tag == "EnemyViewFrustrum") {
            EnemyDetectorComponent detector = other.gameObject.GetComponent<EnemyDetectorComponent>();
            if (detector != null)
            {
                detector.DetectedPlayer(this);
            }
            else
            {
                Debug.LogError("ViewDetector has not DetectorComponent");
            }
		}
	}
	
	void OnTriggerExit2D ( Collider2D other ) {
		Debug.Log ("OnTriggerExit " + other.name + " " + other.tag);
        if (other.tag == "EnemyViewFrustrum")
        {
            EnemyDetectorComponent detector = other.gameObject.GetComponent<EnemyDetectorComponent>();
            if (detector != null)
            {
                detector.NoDetectPlayer(this);
            }
            else
            {
                Debug.LogError("ViewDetector has no DetectorComponent");
            }
        }
	}
	
	void OnCollisionEnter2D ( Collision2D other ) {
		if (other.collider.tag == "EnemyCollider") {
			GameManager.SharedManager.LostALife();
		}
	}

	// Spawn Points
	public void DieAndGoToSpawnPoint (SpawnPoint spawnPoint) {
        //if (spawnPoint == null)
        //{
            this.transform.position = spawnPoint.transform.position;
            movementComponent.StopAllMovement();
        //}
        //else
        //{
        //    Debug.LogError("Error : Spawn Point not set");
        //}
	}
}
