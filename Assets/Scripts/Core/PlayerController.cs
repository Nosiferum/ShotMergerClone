using ShotMergerClone.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class PlayerController : BulletSpawner
    {
        [SerializeField] private float forwardSpeed = 10f;
        [SerializeField] private float horizontalSpeed = 10f;
        [field: SerializeField] public Transform AdditiveTransform { get; private set; }

         public List<AdditiveParentController> FirstParentController { get; set; } = new();
         public bool IsAdditiveListEmpty = true;

        private float minXClamp = -2.07f;
        private float maxXClamp = 2.083f;

        private Action playerState;

        private void Update()
        {
            playerState?.Invoke();
        }

        private void GamePlayState()
        {
            Move();
            SpawnProjectile();
        }

        private void Move()
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

            if (Input.GetMouseButton(0))
            {
                transform.Translate(new Vector3(0, -InputManager.Delta.x, 0) * horizontalSpeed);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXClamp, maxXClamp),
                    transform.position.y, transform.position.z);
            }
        }

        private void StartBroadcast()
        {
            playerState = GamePlayState;
        }

        private void EndBroadcast()
        {
            playerState = null;
        }

        private void OnEnable()
        {
            GameManager.onLevelStart += StartBroadcast;
            GameManager.onLevelOver += EndBroadcast;
        }

        private void OnDisable()
        {
            GameManager.onLevelStart -= StartBroadcast;
            GameManager.onLevelOver -= EndBroadcast;
        }
    }
}

