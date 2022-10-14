using MoreMountains.NiceVibrations;
using ShotMergerClone.Utils;
using UnityEngine;

namespace ShotMergerClone.Core
{
    public class AdditiveParentController : MonoBehaviour
    {
        [field: SerializeField] public GameObject DowngradedAdditiveGO { get; private set; }
        [field: SerializeField] public int CollectorAdditorColumnHeight { get; set; } = 1;

        private AdditiveController[] additiveControllers;

        private void Awake()
        {
            additiveControllers = GetComponentsInChildren<AdditiveController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                if (playerController.IsAdditiveListEmpty)
                {
                    Destroy(GetComponent<AdditiveWrapper>());

                    transform.SetParent(other.gameObject.transform);
                    transform.position = playerController.AdditiveTransform.position;

                    playerController.IsAdditiveListEmpty = false;
                    playerController.FirstParentController.Add(this);

                    MMVibrationManager.Haptic(HapticTypes.LightImpact);

                    StartShooting();
                }
            }

            else if (other.TryGetComponent(out AdditiveWrapper additiveWrapper))
            {
                if (!transform.CompareTag("Addable"))
                    return;
                
                Destroy(additiveWrapper);
                transform.tag = "None";

                Transform otherTransform = other.transform;
                otherTransform.SetParent(gameObject.transform.parent.transform);

                if (CollectorAdditorColumnHeight == 1)
                    otherTransform.position = GetComponent<Collider>().bounds.center + new Vector3(0, 0, 0.27f);

                else if (CollectorAdditorColumnHeight == 2)
                    otherTransform.position = GetComponent<Collider>().bounds.center + new Vector3(0, 0, 0.38f);

                else if (CollectorAdditorColumnHeight == 3)
                    otherTransform.position = GetComponent<Collider>().bounds.center + new Vector3(0, 0, 0.50f);

                var otherAdditiveParentController = other.GetComponent<AdditiveParentController>();

                GetComponentInParent<PlayerController>().FirstParentController.Add(otherAdditiveParentController);

                MMVibrationManager.Haptic(HapticTypes.LightImpact);

                otherAdditiveParentController.StartShooting();
            }
        }

        public void StartShooting()
        {
            foreach (var additiveController in additiveControllers)
                additiveController.OnAdditivePickedUp?.Invoke();
        }
    }
}


