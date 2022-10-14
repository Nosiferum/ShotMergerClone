using System;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class Health : MonoBehaviour
    {
        [field:SerializeField] public float BarrelHealth { get; private set; }
        
        [SerializeField] private ParticleSystem particleSystem;

        public Action OnTakenDamage;

        public void TakeDamage()
        {
            BarrelHealth--;
            OnTakenDamage?.Invoke();
            MMVibrationManager.Haptic(HapticTypes.LightImpact);

            if (BarrelHealth <= 0)
            {
                transform.DOShakeScale(0.2f).OnComplete(delegate
                {
                    particleSystem.Play(); 
                    Destroy(gameObject, 0.1f);

                }).SetLink(gameObject);
            }
        }
    }
}


