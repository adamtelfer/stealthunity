using UnityEngine;
using System.Collections;

public class SpriteUpdaterComponent : MonoBehaviour {

	public MovementComponent movementComponent;
	public Animator animatorComponent;

	public string idleState = "PlayerIdle";
	public string moveState = "PlayerWalk";

	void Start() {
		movementComponent.movementStateUpdateDelegate += MovementStateChange;
		movementComponent.facingDirectionUpdateDelegate += FacingDirectionChange;
		MovementStateChange(movementComponent);
		FacingDirectionChange(movementComponent);
	}

	public void FacingDirectionChange ( MovementComponent m ) {

	}

	public void MovementStateChange ( MovementComponent m ) {
		if (m.CurrentMovementState == MovementComponent.MovementState.Stopped) {
			animatorComponent.Play (idleState);
		} else if (m.CurrentMovementState == MovementComponent.MovementState.Moving) {
			animatorComponent.Play (moveState);
		}
	}
}
