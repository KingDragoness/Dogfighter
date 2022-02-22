using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogfighter
{

    public class CameraShip : MonoBehaviour
    {
        public Transform anchorInteriorTransform;
        public Transform rotation1;
        public Transform player;
        public Vector3 localPosOffset = Vector3.zero;

        public Camera originCamera;
        public Camera targetCamera;

        public float parallaxEffect = 250f;

        private void Update()
        {
            targetCamera.transform.localRotation = originCamera.transform.localRotation;
            targetCamera.fieldOfView = originCamera.fieldOfView;

            Vector3 playerLocalPos = player.transform.position - anchorInteriorTransform.position;

            targetCamera.transform.localPosition = playerLocalPos + localPosOffset;
        }

    }
}