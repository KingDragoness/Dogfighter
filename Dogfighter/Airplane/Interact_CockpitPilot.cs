using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pragma;
using Sirenix.OdinInspector;

namespace Dogfighter
{

    [RequireComponent(typeof(Interact_ThirdCamera))]
    public class Interact_CockpitPilot : InteractableScript
    {

        public PlayerAirplane airplaneScript;
        public UnityEvent OnPilotMode;
        public UnityEvent OnExitPilot;
        public Interact_ThirdCamera thirdCamera;

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

        [Button("Debug: Toggle Pilot")]
        public void TogglePilotMode()
        {
            isPilotMode = !isPilotMode;

            if (isPilotMode)
            {
                Interactions.EnterThirdCamera(thirdCamera);
                airplaneScript.EnableInput(true);

                Command_Sit.CommandDisplay = "Standup";
                OnPilotMode?.Invoke();
            }
            else
            {
                Interactions.ExitThirdCamera();
                airplaneScript.EnableInput(false);

                Command_Sit.CommandDisplay = "Sit";
                OnExitPilot?.Invoke();
            }

        }

    }
}
