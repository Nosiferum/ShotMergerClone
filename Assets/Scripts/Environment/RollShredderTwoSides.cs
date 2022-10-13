using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EzySlice;
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

                    Destroy(other.transform.gameObject);

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
            rb.AddForce(-new Vector3(1, -2, 0), ForceMode.Impulse);
        }
    }
}


