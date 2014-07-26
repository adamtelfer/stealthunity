using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Movement)]
    [Tooltip("AI Player Detects Player")]
    public class AlertedAction : FsmStateAction
    {
        public EnemyController enemyController;

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
            enemyController.movementComponent.StopAllMovement(); 
            Finish();
        }
    }
}
