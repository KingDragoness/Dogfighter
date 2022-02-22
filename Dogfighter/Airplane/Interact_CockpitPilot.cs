using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pragma;

namespace Dogfighter
{

    public class Interact_CockpitPilot : InteractableScript, IOffCamerable
    {

        public GameObject virtualCamera;
        public PlayerAirplane airplaneScript;
        public UnityEvent OnPilotMode;
        public UnityEvent OnExitPilot;

        private bool isPilotMode = false;
        private InteractCommand Command_Sit;

        private void Awake()
        {
            Command_Sit = CommandContainer.InteractCommands[0];
            Command_Sit.CommandDisplay = "Sit";
        }

        public override string GetDescription()
        {
            return "Meh";
        }

        public GameObject VirtualCamera()
        {
            return virtualCamera;
        }

        public void TogglePilotMode()
        {
            isPilotMode = !isPilotMode;

            if (isPilotMode)
            {
                GameplayManager.ChangeGamemode(PragmaClass.Gamemode.Offcamera);
                GameplayManager.SetOffCamerable(this);
                airplaneScript.EnableInput(true);

                Command_Sit.CommandDisplay = "Standup";
                OnPilotMode?.Invoke();
            }
            else
            {
                GameplayManager.ChangeGamemode(PragmaClass.Gamemode.FirstPerson);
                airplaneScript.EnableInput(false);

                Command_Sit.CommandDisplay = "Sit";
                OnExitPilot?.Invoke();
            }

        }

    }
}
