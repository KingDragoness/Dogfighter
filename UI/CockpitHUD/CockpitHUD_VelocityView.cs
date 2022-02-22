using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class CockpitHUD_VelocityView : MonoBehaviour
    {

        public MotherplaneController MotherplaneController;
        public Text valueLabelVelocity;
        public Slider sliderVelocity;

        private void Update()
        {
            valueLabelVelocity.text = $"{Mathf.RoundToInt(MotherplaneController.Velocity)}";
            sliderVelocity.value = MotherplaneController.Velocity;
        }


    }
}