using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ShotMergerClone.Core;
using TMPro;
using UnityEngine;

namespace ShotMergerClone.UI
{
    public class BarrelHealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;

        private Health health;

        private void Awake()
        {
            health = GetComponent<Health>();
        }

        private void Start()
        {
            healthText.text = health.BarrelHealth.ToString(CultureInfo.InvariantCulture);
        }
    }
}


