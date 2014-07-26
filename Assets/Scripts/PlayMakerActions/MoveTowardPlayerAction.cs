using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Movement)]
    [Tooltip("Move towards the alerted Player")]
    public class MoveTowardPlayerAction : FsmStateAction
    {
        public EnemyController enemyController;

        public float speed = 0.2f;

        public override void Reset()
        {
            enemyController = this.Owner.GetComponent<EnemyController>();
            if (enemyController == null)
            {
                Debug.LogError("Did not set Enemy Controller");
            }
        }

        public override void OnEnter()
        {
            if (enemyController.alerted)
            {
                enemyController.movementComponent.SetTarget(new Vector3(enemyController.lastKnownPosition.x, enemyController.lastKnownPosition.y, 0f), speed);
            }
            else
            {
                PlayMakerFSM.BroadcastEvent("ALERT_PLAYERLOST");
            }
            Finish();
        }
    }
}
