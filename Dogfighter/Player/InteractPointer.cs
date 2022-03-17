using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pragma;

namespace Dogfighter
{
    public class InteractPointer : MonoBehaviour
    {

        public LayerMask objectMask;

        [SerializeField]
        private InteractableScript currentInteractable;

        private GameObject currentGameobjectLookAt;

        public GameObject CurrentGameobjectLookAt
        {
            get => currentGameobjectLookAt;
            private set => currentGameobjectLookAt = value;
        }

        public InteractableScript CurrentInteractable
        {
            get => currentInteractable;
        }

        private void FixedUpdate()
        {
            bool hasInteractable = false;
            var cam = QuickReferencor.MainCamera;
            //Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 50, objectMask))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.distance < 10)
                {
                    var interactScript = hit.collider.GetComponent<InteractableScript>();

                    if (interactScript != null)
                    {
                        currentInteractable = interactScript;
                        hasInteractable = true;
                    }
                }
            }

            if (hasInteractable == false)
            {
                currentInteractable = null;
            }

        }

    }
}