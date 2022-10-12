using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class Health : MonoBehaviour
    {
        [field:SerializeField] public float BarrelHealth { get; private set; }

        public Action OnTakenDamage;

        public void TakeDamage()
        {
            BarrelHealth--;
            OnTakenDamage?.Invoke();

            if (BarrelHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}


