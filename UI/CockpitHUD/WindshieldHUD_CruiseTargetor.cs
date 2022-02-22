using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dogfighter
{
    public class WindshieldHUD_CruiseTargetor : MonoBehaviour
    {

        public Transform objectTarget;
        public Camera cameraShip;
        public RectTransform targetor;

        private void Update()
        {
            targetor.anchoredPosition = cameraShip.WorldToScreenPoint(objectTarget.position);
            var Vector3 = cameraShip.transform.InverseTransformPoint(objectTarget.position);

            if (Vector3.z < 0)
            {
                targetor.gameObject.SetActive(false);
            }
            else
            {
                targetor.gameObject.SetActive(true);

            }

        }

    }
}