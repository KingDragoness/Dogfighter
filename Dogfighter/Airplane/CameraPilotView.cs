using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityUtilities;
using Pragma;

namespace Dogfighter
{

    public class CameraPilotView : MonoBehaviour
    {

        public CinemachineVirtualCamera virtualCamera;
        public MouseLook mouseLookCamera;

        [Space]
        public float fovNumberSpeed = 0;
        public float fovZoomSpeed = 0;
        public RangeFloat cameraLimit;

        private float _targetFOV = 0;
        private float _startMouseLookXSpeed = 0;
        private float _startMouseLookYSpeed = 0;

        private void Start()
        {
            _startMouseLookXSpeed = mouseLookCamera.sensitivityX;
            _startMouseLookYSpeed = mouseLookCamera.sensitivityY;
            _targetFOV = virtualCamera.m_Lens.FieldOfView;
        }

        private float _cacheFOVDelta;

        private void Update()
        {
            CameraZoom();

            MouseLook();
        }

        private void CameraZoom()
        {
            var currentFOV = virtualCamera.m_Lens.FieldOfView;
            float scroll1 = Input.mouseScrollDelta.y;

            _targetFOV += fovNumberSpeed * scroll1 * Time.deltaTime;
            _cacheFOVDelta = Mathf.MoveTowards(currentFOV, _targetFOV, fovZoomSpeed * Time.deltaTime);
            virtualCamera.m_Lens.FieldOfView = _cacheFOVDelta;
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(virtualCamera.m_Lens.FieldOfView, cameraLimit.From, cameraLimit.To);
            _targetFOV = Mathf.Clamp(_targetFOV, cameraLimit.From, cameraLimit.To);

        }

        private void MouseLook()
        {

            if (Cursor.lockState == CursorLockMode.None)
            {
                mouseLookCamera.sensitivityX = _startMouseLookXSpeed * 0.1f;
                mouseLookCamera.sensitivityY = _startMouseLookYSpeed * 0.1f;
            }
            else
            {
                mouseLookCamera.sensitivityX = _startMouseLookXSpeed ;
                mouseLookCamera.sensitivityY = _startMouseLookYSpeed ;
            }
        }

    }
}