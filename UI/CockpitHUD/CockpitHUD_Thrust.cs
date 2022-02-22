using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dogfighter
{

    public class CockpitHUD_Thrust : MonoBehaviour
    {

        public MotherplaneController MotherplaneController;
        public Text textValue;
        public Slider thrustSlider;

        private void Update()
        {
            var thrust = MotherplaneController.ThrustPercent;
            var displayThrust = (Mathf.Round(thrust * 100f));
            textValue.text = displayThrust.ToString() + "%";
            thrustSlider.value = thrust;
        }

    }
}