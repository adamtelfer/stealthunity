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
            if (enemyController == null)
            {
                Debug.LogError("Did not set Enemy Controller");
            }



            Finish();
        }
    }
}
