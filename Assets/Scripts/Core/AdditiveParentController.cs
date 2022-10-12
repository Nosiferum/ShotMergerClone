using ShotMergerClone.Utils;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class AdditiveParentController : MonoBehaviour
    {
        private AdditiveController[] additiveControllers;

        private void Awake()
        {
            additiveControllers = GetComponentsInChildren<AdditiveController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                Destroy(GetComponent<AdditiveWrapper>());
                transform.SetParent(other.gameObject.transform);
                 transform.position = playerController.AdditiveTransform.position;

                foreach (var additiveController in additiveControllers)
                    additiveController.OnAdditivePickedUp?.Invoke();
            }

            else if (other.TryGetComponent(out AdditiveWrapper additiveWrapper))
            {
                Destroy(additiveWrapper);
                other.transform.SetParent(gameObject.transform.parent.transform);
                other.transform.position = GetComponent<Collider>().bounds.center + new Vector3(0,0, 0.25f);

                foreach (var additiveController in additiveControllers)
                    additiveController.OnAdditivePickedUp?.Invoke();
            }
        }
    }
}


