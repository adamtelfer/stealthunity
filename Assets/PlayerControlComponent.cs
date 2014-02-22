using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayerControlComponent : MonoBehaviour {

	public GameObject playerObject;

	public float playerSpeed = 3;
	public EaseType easeType = EaseType.Linear;

	void OnTap(TapGesture gesture) { 
		Debug.Log( "Tap gesture detected at " + gesture.Position + 
		          ". It was sent by " + gesture.Recognizer.name );

		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (gesture.Position.x, gesture.Position.y, 0f));
		worldPosition = new Vector3 (worldPosition.x, worldPosition.y, 0f);

		//playerObject.transform.position = worldPosition;

		HOTween.To(playerObject.transform, playerSpeed, new TweenParms()
		           .Prop("position", worldPosition, false) // Position tween (set as relative)
		           .Ease(easeType) // Ease
		           );

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
