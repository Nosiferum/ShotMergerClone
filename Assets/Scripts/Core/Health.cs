using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
                transform.DOShakeScale(0.2f).OnComplete(delegate { Destroy(gameObject); });
            }
        }

    }
}


