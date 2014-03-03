using UnityEngine;
using System.Collections;

public class SpriteUpdaterComponent : MonoBehaviour {

	public MovementComponent movementComponent;
	public Animator animatorComponent;

	public string idleState = "PlayerIdle";
	public string moveState = "PlayerWalk";

	public string rightState = "Right";
	public string leftState = "Left";
	public string upState = "Up";
	public string downState = "Down";

	void Start() {
		movementComponent.movementStateUpdateDelegate += MovementStateChange;
		movementComponent.facingDirectionUpdateDelegate += FacingDirectionChange;
		MovementStateChange(movementComponent);
		FacingDirectionChange(movementComponent);
	}

	public void UpdateAnimator ( MovementComponent m ) {
		string animatorState = "";
		if (m.CurrentMovementState == MovementComponent.MovementState.Stopped) {
			animatorState = idleState;
		} else if (m.CurrentMovementState == MovementComponent.MovementState.Moving) {
			animatorState = moveState;
		}

		if (m.CurrentFacingDirection == MovementComponent.FacingDirection.Left) {
			animatorState += leftState;
		} else if (m.CurrentFacingDirection == MovementComponent.FacingDirection.Right) {
			animatorState += rightState;
		} else if (m.CurrentFacingDirection == MovementComponent.FacingDirection.Down) {
			animatorState += downState;
		} else {
			animatorState += upState;
		}

		Debug.Log ("Play State: " + animatorState);
		animatorComponent.Play (animatorState);

	}

	public void FacingDirectionChange ( MovementComponent m ) {
		UpdateAnimator (m);
	}

	public void MovementStateChange ( MovementComponent m ) {
		UpdateAnimator (m);
	}
}
