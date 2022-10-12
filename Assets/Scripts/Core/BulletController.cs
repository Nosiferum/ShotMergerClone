using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float firingSpeed = 10f;

        private float lifespan = 0;

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            lifespan += Time.deltaTime;

            transform.Translate(Vector3.up * Time.deltaTime * firingSpeed, Space.Self);

            if (lifespan >= 3f)
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


