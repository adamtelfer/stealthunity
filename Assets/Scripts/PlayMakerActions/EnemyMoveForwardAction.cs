﻿using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Movement)]
    [Tooltip("Moves AI Character forward")]
    public class EnemyMoveForwardAction : FsmStateAction
    {
        public EnemyController enemyController;

        public float range = 20f;

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
            enemyController.movementComponent.SetTarget(new Vector3(UnityEngine.Random.Range(-range, range), UnityEngine.Random.Range(-range, range), 0f) + this.Owner.transform.position, 0.2f);
            Finish();
        }
    }
}
