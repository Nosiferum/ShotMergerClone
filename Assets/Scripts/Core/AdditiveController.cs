using System;
using System.Collections;
using System.Collections.Generic;
using ShotMergerClone.Managers;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class AdditiveController : BulletSpawner
    {
        public Action OnAdditivePickedUp;
        private Action additiveState;

        private void Update()
        {
            additiveState?.Invoke();
        }

        private void StartBroadcast()
        {
            additiveState = SpawnProjectile;
        }

        private void EndBroadCast()
        {
            additiveState = null;
        }

        private void OnEnable()
        {
            OnAdditivePickedUp += StartBroadcast;
            GameManager.onLevelOver += EndBroadCast;
        }

        private void OnDisable()
        {
            OnAdditivePickedUp -= StartBroadcast;
            GameManager.onLevelOver -= EndBroadCast;
        }
    }
}
