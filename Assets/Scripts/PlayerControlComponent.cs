﻿using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayerControlComponent : MonoBehaviour {

	public GameObject playerObject;
    private Transform playerTransform;
    private Rigidbody2D playerRigidBody;

    public GameObject targetVisual;

    public float maxDistance = 4.0f;
	public float playerSpeed = 1f;
	public float doubleSpeed = 2f;

	public EaseType easeType = EaseType.Linear;

	public Vector3 currentTarget;
    public float startTargetTime;

	void GoToGestureTarget ( Gesture gesture ) {
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (gesture.Position.x, gesture.Position.y, 0f));
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 0f);
		GoToPosition (worldPosition);
	}

	void GoToPosition ( Vector3 worldPosition ) {
		currentTarget = worldPosition;
        startTargetTime = Time.time;
	}

	void OnDoubleTap (TapGesture gesture) {
		GoToGestureTarget (gesture);
	}

	void OnLongPress(LongPressGesture gesture) { 

		//Debug.Log( "Short gesture detected at " + gesture.Position + ". It was sent by " + gesture.Recognizer.name + " state : " + gesture.State);
		
		GoToGestureTarget (gesture);  
	
	}

	void OnTap(TapGesture gesture) { 
		//Debug.Log( "Tap gesture detected at " + gesture.Position + 
		//          ". It was sent by " + gesture.Recognizer.name + " state : " + gesture.State);

		GoToGestureTarget (gesture); 
	
	}

	void OnDrag(DragGesture gesture) {
		//Debug.Log( "Drag gesture detected at " + gesture.Position + 
		//          ". It was sent by " + gesture.Recognizer.name + " state : " + gesture.State);

		GoToGestureTarget (gesture);
	}

	// Use this for initialization
	void Start () {
        playerTransform = playerObject.transform;
        playerRigidBody = playerObject.rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 relativeTarget = currentTarget - playerTransform.position;
        float timeFactor = (1f - (Mathf.Min(Time.time - startTargetTime,5.0f) / 5.0f));
		float s = playerSpeed;
        playerRigidBody.velocity = relativeTarget * timeFactor * s;

	}
}