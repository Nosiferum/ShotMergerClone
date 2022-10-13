using ShotMergerClone.Utils;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class AdditiveParentController : MonoBehaviour
    {
        [field:SerializeField] public GameObject DowngradedAdditiveGO { get; private set; }

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

                StartShooting();
            }

            else if (other.TryGetComponent(out AdditiveWrapper additiveWrapper))
            {
                Destroy(additiveWrapper);

                Transform otherTransform = other.transform;
                otherTransform.SetParent(gameObject.transform.parent.transform);
                otherTransform.position = GetComponent<Collider>().bounds.center + new Vector3(0, 0, 0.25f);

                other.GetComponent<AdditiveParentController>().StartShooting();
            }
        }

        public void StartShooting()
        {
            foreach (var additiveController in additiveControllers)
                additiveController.OnAdditivePickedUp?.Invoke();
        }
    }
}


