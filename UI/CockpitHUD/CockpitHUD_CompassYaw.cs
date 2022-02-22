using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{


    public class CockpitHUD_CompassYaw : MonoBehaviour
    {

        public MotherplaneController MotherplaneController;
        public RectTransform compassTransform;
        public CockpitHUD_CompassLabelButton templateMarker;

        private List<CockpitHUD_CompassLabelButton> compassDirectionLabels = new List<CockpitHUD_CompassLabelButton>();

        private void Start()
        {
            int index = 0;

            var values = System.Enum.GetValues(typeof(CockpitHUD_CompassLabelButton.TypeMarker)).Cast<CockpitHUD_CompassLabelButton.TypeMarker>(); ;

            foreach(var value in values)
            {
                if (value == CockpitHUD_CompassLabelButton.TypeMarker.Objective)
                {
                    break;
                }

                CockpitHUD_CompassLabelButton labelButton = Instantiate(templateMarker, transform);
                labelButton.gameObject.SetActive(true);
                string dir = value.ToString();

                labelButton.textCompass.text = dir;
                labelButton.direction = value;

                compassDirectionLabels.Add(labelButton);
            }
        }


        private void Update()
        {
            foreach(var compassLabel in compassDirectionLabels)
            {
                Vector3 dir = new Vector3();

                if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.N)
                {
                    dir = Vector3.forward;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.S)
                {
                    dir = Vector3.back;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.E)
                {
                    dir = Vector3.right;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.W)
                {
                    dir = Vector3.left;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.NE)
                {
                    dir = Vector3.right + Vector3.forward;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.NW)
                {
                    dir = Vector3.left + Vector3.forward;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.SE)
                {
                    dir = Vector3.right + Vector3.back;
                }
                else if (compassLabel.direction == CockpitHUD_CompassLabelButton.TypeMarker.SW)
                {
                    dir = Vector3.left + Vector3.back;
                }

                SetMarkerPosition(compassLabel.rectTransform, dir, true);

            }
        }

        private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPos, bool useOrigin = false)
        {
            Vector3 directionToTarget = new Vector3();
            float angle = 0;

            if (useOrigin == false)
            {
                directionToTarget = worldPos - MotherplaneController.transform.position;
            }
            else
            {
                directionToTarget = worldPos - Vector3.zero;
                //angle = Vector2.SignedAngle(new Vector2(directionToTarget.x, directionToTarget.z), new Vector2(Vector3.forward.x, Vector3.forward.z));

            }

            angle = Vector2.SignedAngle(new Vector2(directionToTarget.x, directionToTarget.z), new Vector2(MotherplaneController.transform.forward.x, MotherplaneController.transform.forward.z));


            float maxRectWidth = compassTransform.rect.width / 2;
            var t = (angle + 180f) / 360f;
            var compassPositionX = Mathf.Lerp(-maxRectWidth, maxRectWidth, t);

            markerTransform.anchoredPosition = new Vector2(compassPositionX, 0);
        }

    }
}