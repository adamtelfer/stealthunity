
using UnityEngine;
using System.Collections;

public class RotateTransformBehaviour : MonoBehaviour
{
	public Vector3 Amount = Vector3.up;
	
	void Update ()
	{
		transform.Rotate(Amount * Time.smoothDeltaTime);
	}
}