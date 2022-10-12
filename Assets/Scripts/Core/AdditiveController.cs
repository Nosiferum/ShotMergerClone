using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class AdditiveController : BulletSpawner
    {
        [SerializeField] private int additiveNumber = 1;

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

        private void OnEnable()
        {
            OnAdditivePickedUp += StartBroadcast;
        }

        private void OnDisable()
        {
            OnAdditivePickedUp -= StartBroadcast;
        }
    }
}
