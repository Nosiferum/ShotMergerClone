using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EzySlice;
using ShotMergerClone.Core;
using UnityEngine;

namespace Twenty.Collectibles
{
    public class RollShredderTwoSides : MonoBehaviour
    {
        public SlicedHull SliceObject1(GameObject obj, Transform sideTransform, Material crossSectionMaterial = null)
        {
            // slice the provided object using the transforms of this object
            return obj.Slice(sideTransform.position, transform.right, crossSectionMaterial);
        }  
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Additive"))
            {
                SlicedHull hull1 = SliceObject1(other.gameObject, transform);
                
                if (hull1 != null)
                {
                    GameObject lowerHull = hull1.CreateLowerHull(other.gameObject, null);
                    GameObject upperHull = hull1.CreateUpperHull(other.gameObject, null);

                    var additiveParentController = other.GetComponentInParent<AdditiveParentController>();
                    var playerController = other.GetComponentInParent<PlayerController>();

                    if (additiveParentController.DowngradedAdditiveGO != null)
                    {
                        var newAdditive = Instantiate(additiveParentController.DowngradedAdditiveGO,other.transform.parent.transform.position,
                            Quaternion.identity, playerController.transform);

                        newAdditive.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                        newAdditive.GetComponent<AdditiveParentController>().StartShooting();
                    }
                   
                    Destroy(other.transform.parent.gameObject);

                    AddForceToHull(lowerHull);
                    AddForceToHull(upperHull);
                }
            }
        }

        private void AddForceToHull(GameObject hull)
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


