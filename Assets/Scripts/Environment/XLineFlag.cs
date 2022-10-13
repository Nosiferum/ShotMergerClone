using System;
using System.Collections;
using System.Collections.Generic;
using ShotMergerClone.Core;
using UnityEngine;

namespace ShotMergerClone.Environment
{
    public class XLineFlag : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                playerController.ForwardSpeed += .3f;
            }
        }
    }
}


