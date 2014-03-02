using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayerControlComponent : MonoBehaviour {

	public PlayerController playerController;

	private FingerGestures.Finger currentFinger;

	void Start () {
		currentFinger = null;
	}

	void GoToTouchTarget ( Vector2 position, float speed ) {
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (position.x, position.y, 0f));
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 0f);
		playerController.movementComponent.SetTarget(worldPosition, speed);
	}

	void OnFingerDown(FingerDownEvent e) {
		if (currentFinger == null) {
			currentFinger = e.Finger;
			GoToTouchTarget(e.Position, 1f);
		}
	}

	void OnFingerUp(FingerUpEvent e) {
		if (currentFinger == e.Finger) {
			currentFinger = null;
            GoToTouchTarget(e.Position, 1f);
		}
	}

	void OnFingerMove(FingerMotionEvent e) {
        if (currentFinger == e.Finger)
        {
            GoToTouchTarget(e.Position, 1f);
        }
	}

	void OnFingerStationary(FingerMotionEvent e) { 
		if (currentFinger == e.Finger)
        {
            GoToTouchTarget(e.Position, 1f);
        }
	}
}
