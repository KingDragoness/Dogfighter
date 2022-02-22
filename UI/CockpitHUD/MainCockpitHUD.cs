using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Dogfighter
{

    public class MainCockpitHUD : MonoBehaviour
    {

        [FoldoutGroup("Cockpit Mode")] public GameObject Deactive_Pilot;
        [FoldoutGroup("Cockpit Mode")] public GameObject Active_Pilot;
        [FoldoutGroup("Cockpit Mode")] public GameObject Deactive_Combat;
        [FoldoutGroup("Cockpit Mode")] public GameObject Active_Combat;
        public GameObject cruiseControlIcon;
        public GameObject weaponHUD;
        public GameObject weaponHUD_Windshield;

        public PlayerAirplane playerAirplane;

        private MotherplaneController shipController;

        private void Update()
        {
            shipController = playerAirplane.shipController;

            HUD();
        }
        private void HUD()
        {
            if (playerAirplane.currentPilotMode == PlayerAirplane.Mode.Pilot)
            {
                Deactive_Pilot.SetActive(false);
                Active_Pilot.SetActive(true);
                Deactive_Combat.SetActive(true);
                Active_Combat.SetActive(false);
                weaponHUD.SetActive(false);
                weaponHUD_Windshield.SetActive(false);
            }
            else if (playerAirplane.currentPilotMode == PlayerAirplane.Mode.Combat)
            {
                Deactive_Pilot.SetActive(true);
                Active_Pilot.SetActive(false);
                Deactive_Combat.SetActive(false);
                Active_Combat.SetActive(true);
                weaponHUD.SetActive(true);
                weaponHUD_Windshield.SetActive(true);
            }

            cruiseControlIcon.gameObject.SetActive(shipController.cruiserControlMode);

        }

    }
}