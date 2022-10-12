using UnityEngine;

namespace ShotMergerClone.Core
{
    public class BulletSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected GameObject bulletGO;
        [SerializeField] protected Transform bulletSpawnTransform; 
        [Header("Core")]
        [SerializeField] protected float spawnDelay = 2f;

        protected float innerSpawnDelay;

        protected void SpawnProjectile()
        {
            innerSpawnDelay -= Time.deltaTime;

            if (innerSpawnDelay <= 0)
            {
                Instantiate(bulletGO, bulletSpawnTransform.position, bulletGO.transform.rotation);
                innerSpawnDelay = spawnDelay;
            }
        }
    }
}