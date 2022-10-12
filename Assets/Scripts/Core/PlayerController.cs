using System;
using ShotMergerClone.Managers;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject bulletGO;
        [SerializeField] private Transform bulletSpawnTransform;
        [SerializeField] private float spawnDelay = 2f;
        [SerializeField] private float movementSpeed = 10f;

        private float innerSpawnDelay;
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
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);

            if (Input.GetMouseButton(0))
            {
                transform.Translate(new Vector3(0, -InputManager.Delta.x, 0));
            }
        }

        private void SpawnProjectile()
        {
            innerSpawnDelay -= Time.deltaTime;

            if (innerSpawnDelay <= 0)
            {
                var bullet = Instantiate(bulletGO, bulletSpawnTransform.position, bulletGO.transform.rotation);
                innerSpawnDelay = spawnDelay;
            }
        }

        private void StartBroadcast()
        {
            playerState = GamePlayState;
        }

        private void OnEnable()
        {
            GameManager.onLevelStart += StartBroadcast;
        }

        private void OnDisable()
        {
            GameManager.onLevelStart -= StartBroadcast;
        }
    }
}

