using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pragma;

namespace Dogfighter
{
    public class Interact_TestButton : InteractableScript, IOffCamerable
    {

        public GameObject pointLight;
        public GameObject virtualCamera;

        public bool isTurnedOn = false;

        public override string GetDescription()
        {
            return "";
        }

        public override void Interact(InteractCommand interactCommand)
        {
            if (interactCommand.CommandID == "default")
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

            base.Interact(interactCommand);
        }

        public void ThirdPersonMode()
        {
            GameplayManager.ChangeGamemode(PragmaClass.Gamemode.Offcamera);
            GameplayManager.SetOffCamerable(this);
        }

        public GameObject VirtualCamera()
        {
            return virtualCamera;
        }
    }
}