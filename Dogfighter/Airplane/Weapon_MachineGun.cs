using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogfighter
{

    public class Weapon_MachineGun : MonoBehaviour
    {

        public bool enableMachineGun = false;
        public Camera shipCamera;
        public GameObject pointerTarget;
        public GameObject VFX_machineGun;
        public AudioSource Audio_FinishedFire;
        public ParticleSystem MachineGunparticle;
        public float machineGunRateParticle = 20;

        private void Start()
        {
            var emission = MachineGunparticle.emission;
            emission.rateOverTime = 0;
        }

        bool _justFinishedFiring = false;

        private void Update()
        {
            if (enableMachineGun == false) return;
            if (GameplayManager.IsPaused) { StopMachineGun(); return; }

            ProcessRotation();

            if (Input.GetButton("Fire1"))
            {
                var emission = MachineGunparticle.emission;
                emission.rateOverTime = machineGunRateParticle;

                VFX_machineGun.gameObject.SetActive(true);
                _justFinishedFiring = false;
            }
            else
            {
                if (!_justFinishedFiring) Audio_FinishedFire.Play();
                StopMachineGun();

                _justFinishedFiring = true;
            }

            if (Input.GetButton("Fire2")) SetTarget();
        }

        private void ProcessRotation()
        {
            var _direction = (pointerTarget.transform.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            var _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 100);
        }

        private void SetTarget()
        {
            var targetPos = shipCamera.transform.position + shipCamera.transform.forward * 32000;

            pointerTarget.transform.position = targetPos;
        }


        public void EnableWeapon()
        {
            enableMachineGun = true;
        }

        public void DisableWeapon()
        {
            enableMachineGun = false;
        }

        private void StopMachineGun()
        {
            var emission = MachineGunparticle.emission;
            emission.rateOverTime = 0;

            VFX_machineGun.gameObject.SetActive(false);
        }

    }
}