using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayerControlComponent : MonoBehaviour {

	public GameObject playerObject;
	public float playerSpeed = 3;
	public EaseType easeType = EaseType.Linear;

	public Vector3 currentTarget;
	private Tweener currentTween = null;

	void GoToGestureTarget ( Gesture gesture ) {
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (gesture.Position.x, gesture.Position.y, 0f));
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 0f);
		GoToPosition (worldPosition);
	}

	void GoToPosition ( Vector3 worldPosition ) {
		currentTarget = worldPosition;
		if (currentTween != null) {
			currentTween.Kill ();
		}
		currentTween = HOTween.To (playerObject.transform, playerSpeed, new TweenParms()
		                           .Prop("position", currentTarget, false) // Position tween (set as relative)
		                           .Ease(easeType) // Ease
		                           );
	}

	void OnTap(TapGesture gesture) { 
		Debug.Log( "Tap gesture detected at " + gesture.Position + 
		          ". It was sent by " + gesture.Recognizer.name + " state : " + gesture.State);

		GoToGestureTarget (gesture); 
	
	}

	void OnDrag(DragGesture gesture) {
		Debug.Log( "Drag gesture detected at " + gesture.Position + 
		          ". It was sent by " + gesture.Recognizer.name + " state : " + gesture.State);

		GoToGestureTarget (gesture);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
