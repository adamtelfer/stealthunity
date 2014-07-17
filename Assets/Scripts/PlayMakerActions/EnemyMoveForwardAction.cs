using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Movement)]
    [Tooltip("Moves AI Character forward")]
    public class EnemyMoveForwardAction : FsmStateAction
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
            Debug.Log("Move Enemy");
            enemyController.movementComponent.SetTarget(new Vector3(UnityEngine.Random.Range(-5,5),UnityEngine.Random.Range(-5,5),0f) + this.Owner.transform.position,0.2f);
            Finish();
        }
    }
}
