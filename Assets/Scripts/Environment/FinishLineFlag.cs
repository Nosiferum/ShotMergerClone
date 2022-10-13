using System;
using System.Collections;
using System.Collections.Generic;
using ShotMergerClone.Core;
using ShotMergerClone.Managers;
using UnityEngine;

namespace ShotMergerClone.Environment
{
    public class FinishLineFlag : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.GameSuccess();
               // other.GetComponent<PlayerController>()
            }
        }
    }
}


