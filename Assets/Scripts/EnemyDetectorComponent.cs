using UnityEngine;
using System.Collections;

public class EnemyDetectorComponent : MonoBehaviour {

    public EnemyController rootController;
    public bool alerted = false;

    private PlayerController playerToFollow;

    public delegate void EnemyDetectorAlertChange(EnemyDetectorComponent component, PlayerController player);
    public EnemyDetectorAlertChange enemyDetectorResponder;

	// Use this for initialization
	void Start () {
        alerted = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void DetectedPlayer(PlayerController player)
    {
        Debug.Log("DetectedPlayer");
        alerted = true;
        playerToFollow = player;
        if (enemyDetectorResponder != null) { enemyDetectorResponder(this, player); }
    }

    public void NoDetectPlayer(PlayerController player)
    {
        Debug.Log("NoDetectPlayer");
        if (playerToFollow == player)
        {
            alerted = false;
            playerToFollow = null;
            if (enemyDetectorResponder != null) { enemyDetectorResponder(this, player); }
        }
    }
}
