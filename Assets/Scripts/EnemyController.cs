using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public MovementComponent movementComponent;
    public PlayMakerFSM behavior;
    
    public GameObject detectorRoot;

    public bool alerted = false;
    public PlayerController playerFound;
    public Vector2 lastKnownPosition;

    public static string alertEvent = "ALERTPLAYERFOUND";
    public static string lostEvent = "ALERTPLAYERLOST";

    void DetectorAlertResponse(EnemyDetectorComponent detector, PlayerController player)
    {
        if (detector.alerted)
        {
            Debug.Log(alertEvent);
            behavior.SendEvent(alertEvent);
            alerted = true;
            playerFound = player;
        }
        else
        {
            Debug.Log(lostEvent);
            alerted = false;
            behavior.SendEvent(lostEvent);
        }
    }

	// Use this for initialization
	void Start () {
        if (detectorRoot == null)
        {
            Debug.LogError("No DetectorRoot Set for Enemy Prefab");
        }
        EnemyDetectorComponent[] detectors = detectorRoot.GetComponentsInChildren<EnemyDetectorComponent>();
        foreach (EnemyDetectorComponent dt in detectors) {
            dt.rootController = this;
            dt.enemyDetectorResponder += DetectorAlertResponse;
        }

        lastKnownPosition = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
        if (alerted && playerFound != null)
        {
            lastKnownPosition = new Vector2(playerFound.transform.position.x,playerFound.transform.position.y);
        }
	}

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        if (alerted)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.yellow;
        }
        
        Gizmos.DrawSphere(lastKnownPosition, 0.25f);
    }
}
