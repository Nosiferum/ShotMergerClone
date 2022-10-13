using UnityEngine;

namespace ShotMergerClone.Core
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float bulletForwardSpeed = 10f;
        [SerializeField] private float totalLifespan = 2f;

        private float lifespan = 0;

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            lifespan += Time.deltaTime;

            transform.Translate(Vector3.up * Time.deltaTime * bulletForwardSpeed, Space.Self);

            if (lifespan >= totalLifespan)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}


