using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUtilities;

namespace Dogfighter
{

    public class CockpitHUD_AltitudeIndicator : MonoBehaviour
    {

        public MotherplaneController motherplaneController;
        public RectTransform altitudeImage;
        public RectTransform rotationGyroTarget;
        public CockpitHUD_AltitudeSignButton templateButton;
        public RectTransform parentAltitudeSign;
        public RangeFloat altitudeRangeLimit;
        public float offset = -5;

        private List<CockpitHUD_AltitudeSignButton> altitudeSigns;

        private void Start()
        {
            CreateAltitude();
        }

        private void CreateAltitude()
        {
            for (int i = 45; i >= -45; i -= 5)
            {
                var button1 = Instantiate(templateButton, parentAltitudeSign);
                button1.gameObject.SetActive(true);
                button1.text1.text = $"{i}";
                button1.text2.text = $"{i}";
            }
        }

        private void Update()
        {
            var pitch = -motherplaneController.PitchRotation + 45 - offset;
            var roll = motherplaneController.RollRotation;

            var positionY = Mathf.Lerp(altitudeRangeLimit.From, altitudeRangeLimit.To, pitch / 90f);
            altitudeImage.anchoredPosition = new Vector2(altitudeImage.anchoredPosition.x, positionY);

            var localRot = rotationGyroTarget.localEulerAngles;
            localRot.z = roll;

            rotationGyroTarget.localEulerAngles = localRot;
        }

    }
}