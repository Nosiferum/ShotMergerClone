using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShotMergerClone.Environment
{ 
    public class ShredderRoller : MonoBehaviour
    {
        [SerializeField] private float rollAnglePerSecond = 90f;

        private void Update()
        {
            Roll();
        }

        private void Roll()
        {
            transform.GetChild(0).Rotate(Vector3.back, rollAnglePerSecond * Time.deltaTime, Space.Self);
            transform.GetChild(1).Rotate(Vector3.back, rollAnglePerSecond * Time.deltaTime, Space.Self);
        }
    }
}


