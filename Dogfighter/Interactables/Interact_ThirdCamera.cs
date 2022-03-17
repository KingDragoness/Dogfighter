using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pragma;

namespace Dogfighter
{

    public class Interact_ThirdCamera : MonoBehaviour
    {

        public GameObject cameraObject;

        public void OpenCamera()
        {
            cameraObject.SetActive(true);
        }

        public void CloseCamera()
        {
            cameraObject.SetActive(false);
        }

    }
}