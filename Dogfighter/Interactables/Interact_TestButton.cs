using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pragma;
using Sirenix.OdinInspector;

namespace Dogfighter
{

    [RequireComponent(typeof(Interact_ThirdCamera))]
    public class Interact_TestButton : InteractableScript
    {

        public GameObject pointLight;
        public GameObject virtualCamera;
        public Interact_ThirdCamera thirdCamera;

        public bool isTurnedOn = false;

        private void Awake()
        {
            thirdCamera = GetComponent<Interact_ThirdCamera>();
        }

        public override string GetDescription()
        {
            return "";
        }

        public override void Interact(InteractCommand interactCommand)
        {
            if (interactCommand.CommandID == "default")
            {
                DefaultTurn();
            }

            base.Interact(interactCommand);
        }

        [Button("Debug: Lampu")]
        private void DefaultTurn()
        {
            isTurnedOn = !isTurnedOn;

            if (isTurnedOn)
            {
                pointLight.gameObject.SetActive(false);
            }
            else
            {
                pointLight.gameObject.SetActive(true);
            }
        }

        [Button("Debug: TPS")]
        public void ThirdPersonMode()
        {
            Interactions.EnterThirdCamera(thirdCamera);
        }

        public GameObject VirtualCamera()
        {
            return virtualCamera;
        }
    }
}