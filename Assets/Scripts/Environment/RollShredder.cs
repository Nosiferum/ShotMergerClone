using EzySlice;
using MoreMountains.NiceVibrations;
using ShotMergerClone.Core;
using ShotMergerClone.Utils;
using System.Linq;
using UnityEngine;

namespace ShotMergerClone.Environment
{
    public class RollShredder : MonoBehaviour
    {
        public SlicedHull SliceObject(GameObject obj, Transform sideTransform, Material crossSectionMaterial = null)
        {
            // slice the provided object using the transforms of this object
            return obj.Slice(sideTransform.position, transform.right, crossSectionMaterial);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Additive"))
            {
                SlicedHull hull1 = SliceObject(other.gameObject, transform);

                if (hull1 != null)
                {
                    GameObject lowerHull = hull1.CreateLowerHull(other.gameObject, null);
                    GameObject upperHull = hull1.CreateUpperHull(other.gameObject, null);

                    var additiveParentController = other.GetComponentInParent<AdditiveParentController>();
                    var playerController = other.GetComponentInParent<PlayerController>();

                    if (additiveParentController.DowngradedAdditiveGO != null)
                    {
                        var newAdditive = Instantiate(additiveParentController.DowngradedAdditiveGO, other.transform.parent.transform.position,
                            Quaternion.identity, playerController.transform);

                        newAdditive.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                        Destroy(newAdditive.GetComponent<AdditiveWrapper>());

                        var newAdditiveParentController = newAdditive.GetComponent<AdditiveParentController>();

                        playerController.FirstParentController.Add(newAdditiveParentController);

                        newAdditiveParentController.StartShooting();
                    }

                    playerController.FirstParentController.Remove(additiveParentController);
                    
                    if (playerController.FirstParentController.Count != 0)
                        playerController.FirstParentController.Last().tag = "Addable";

                    else if (playerController.FirstParentController.Count == 0)
                        playerController.IsAdditiveListEmpty = true;

                    Destroy(other.transform.parent.gameObject);

                    MMVibrationManager.Haptic(HapticTypes.MediumImpact);

                    AddForceToHull(lowerHull);
                    AddForceToHull(upperHull);
                }
            }
        }

        protected void AddForceToHull(GameObject hull)
        {
            var rb = hull.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            var meshCollider = hull.AddComponent<MeshCollider>();
            meshCollider.convex = true;
            rb.AddForce(-new Vector3(2, -4, 0), ForceMode.Impulse);
        }
    }
}


