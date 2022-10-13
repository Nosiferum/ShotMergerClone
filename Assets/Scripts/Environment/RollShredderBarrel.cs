using DG.Tweening;
using ShotMergerClone.Managers;
using UnityEngine;

namespace Twenty.Collectibles
{
    public class RollShredderBarrel : RollShredder
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag("Player"))
            {
                other.transform.DOShakeScale(0.5f, 10f, 20).OnComplete(delegate
                {
                    Destroy(other.gameObject);
                    GameManager.GameFail();

                }).SetLink(other.gameObject);
            }
        }
    }
}