using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayerControlComponent : MonoBehaviour {

	public PlayerController playerController;

	void GoToGestureTarget ( Gesture gesture ) {
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (gesture.Position.x, gesture.Position.y, 0f));
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 0f);
		playerController.SetTarget (worldPosition, gesture.Fingers[0]);
	}

	void OnFingerDown(FingerDownEvent e) { /* your code here */ }

	void OnFingerUp(FingerUpEvent e) { /* your code here */ }

	void OnFingerMove(FingerMotionEvent e) { /* your code here */ }

	void OnFingerStationary(FingerMotionEvent e) { /* your code here */ }
}
