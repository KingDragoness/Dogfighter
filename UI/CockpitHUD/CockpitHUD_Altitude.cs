using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class CockpitHUD_Altitude : MonoBehaviour
    {

        public MotherplaneController MotherplaneController;
        public Text valueLabelAlt;

        private void Update()
        {
            valueLabelAlt.text = $"{Mathf.RoundToInt(MotherplaneController.transform.position.y)}m";
        }


    }
}