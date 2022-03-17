using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Pragma;

namespace Dogfighter
{
    public class Interactions : MonoBehaviour
    {

        [SerializeField]
        private Interact_ThirdCamera currentInteract_ThirdCamera;

        private static Interactions instance;

        private void Awake()
        {
            instance = this;    
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                AttemptQuickInteract();
            }
        }

        private void AttemptQuickInteract()
        {
            var Interactable = QuickReferencor.InteractPointer.CurrentInteractable;

            if (Interactable == null) return;
            var QuickCommand = Interactable.GetQuickInteract();
            if (QuickCommand == null) return;

            InteractObject(QuickCommand);
        }

        [Button("Debug: Read Book")]
        public static void ReadBook(ReadableBookObj book)
        {
            MainUI.ReadingBookUI.gameObject.SetActive(true);
            MainUI.ReadingBookUI.currentReadableBook = book;
            GameplayManager.ChangeGamemode(PragmaClass.Gamemode.InteractUI);

        }

        public static void InteractObject(InteractCommand command)
        {
            var Interactable = QuickReferencor.InteractPointer.CurrentInteractable;

            if (Interactable != null) Interactable.Interact(command);
        }

        public static void EnterThirdCamera(Interact_ThirdCamera thirdCamera)
        {
            GameplayManager.ChangeGamemode(PragmaClass.Gamemode.Offcamera);

            if (instance.currentInteract_ThirdCamera != null)
            {
                if (thirdCamera != instance.currentInteract_ThirdCamera) instance.currentInteract_ThirdCamera.CloseCamera();
            }

            instance.currentInteract_ThirdCamera = thirdCamera;
            instance.currentInteract_ThirdCamera.OpenCamera();
        }

        public static void ExitThirdCamera()
        {
            GameplayManager.ChangeGamemode(PragmaClass.Gamemode.FirstPerson);

            instance.currentInteract_ThirdCamera.CloseCamera();
        }

    }
}