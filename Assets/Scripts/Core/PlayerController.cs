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

        private float innerSpawnDelay;
        private Action playerState;

        private void Start()
        {
            innerSpawnDelay = spawnDelay;
        }

        private void Update()
        {
            playerState?.Invoke();
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
            playerState = SpawnProjectile;
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

