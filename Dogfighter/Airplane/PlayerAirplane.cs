using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Pragma;

namespace Dogfighter
{

    public class PlayerAirplane : PragmaScript
    {

        public enum Mode
        {
            Pilot,
            Combat
        }

        public enum WeaponMode
        {
            MachineGun,
            ATG,
            BigMissile,
            Laser,
            SmallMissile
        }


        public MotherplaneController shipController;
        public Camera shipCamera;
        public Mode currentPilotMode;
        [Space]
        [FoldoutGroup("Weapons")] public WeaponMode currentWeaponMode;
        [FoldoutGroup("Weapons")] public Weapon_MachineGun weaponMachineGun;
        [SerializeField]
        private bool isPilotShip = false;



        private Rigidbody rb;

        private bool bfv_isPilotShip = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public override void OnPragmaUpdate()
        {
            if (isPilotShip)
            {
                if (shipController.enableInput) VehicleCommandInput();
                shipController.enabled = true;
                bfv_isPilotShip = true;

            }

            if (isPilotShip == false)
            {
                shipController.enabled = false;
                bfv_isPilotShip = false;
            }

            UpdateWeapon();

            base.OnPragmaUpdate();
        }

        private void UpdateWeapon()
        {
            if (currentPilotMode == Mode.Combat && isPilotShip)
            {
                if (currentWeaponMode == WeaponMode.MachineGun)
                {
                    weaponMachineGun.EnableWeapon();
                }
                else
                {
                    weaponMachineGun.DisableWeapon();

                }
            }
            else
            {
                weaponMachineGun.DisableWeapon();
            }
        }

        private void VehicleCommandInput()
        {
            if (Input.GetKeyUp(KeyCode.G))
            {
                shipController.cruiserControlMode = !shipController.cruiserControlMode;
            }
            else
            {
            }

            if (Input.GetKey(KeyCode.C))
                SetCruiseTarget();

            if (Input.GetKeyUp(KeyCode.X))
            {
                if (currentPilotMode == Mode.Combat)
                {
                    currentPilotMode = Mode.Pilot;
                }
                else if (currentPilotMode == Mode.Pilot)
                {
                    currentPilotMode = Mode.Combat;
                }
            }

        }

        private void SetCruiseTarget()
        {
            var targetPos = shipCamera.transform.position + shipCamera.transform.forward * 32000;

            shipController.targetCruise.position = targetPos;
        }

        public void ToggleEngine()
        {
            isPilotShip = !isPilotShip;
        }

        public void EnableInput(bool enable)
        {
            shipController.enableInput = enable;
        }


    }
}