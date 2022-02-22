using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{
    public class MainUI : MonoBehaviour
    {

        [Header("Tips and Pointers")]
        public Text Label_InteractPointer;
        public GameObject UIObject_MoreInteractions;

        [Space]
        public GameObject mainGameUI;
        public GameObject pauseMenuUI;
        public GameObject blurEffectCamera;


        private void Awake()
        {
            GlobalEngineEvents.OnPauseGame += OnPauseGame;
            GlobalEngineEvents.OnUnpauseGame += OnUnpauseGame;
        }


        private void Start()
        {
            pauseMenuUI.gameObject.SetActive(false);
            blurEffectCamera.SetActive(false);
        }

        private void OnDestroy()
        {
            GlobalEngineEvents.OnPauseGame -= OnPauseGame;
            GlobalEngineEvents.OnUnpauseGame -= OnUnpauseGame;
        }



        private void Update()
        {


            if (GameplayManager.isPaused == false)
            {
                var currentInteract = QuickReferencor.InteractPointer.currentInteractable;

                //if (currentInteract != null)
                //{
                //    var quickCommand = currentInteract.GetQuickInteract();

                //    if (quickCommand != null) Label_InteractPointer.text = "[F] " + quickCommand.CommandDisplay;

                //    Label_InteractPointer.gameObject.SetActive(true);


                //}
                //else
                //{
                //    Label_InteractPointer.gameObject.SetActive(false);
                //}

                if (currentInteract != null)
                {
                    UIObject_MoreInteractions.gameObject.SetActive(true);
                }
                else
                {
                    UIObject_MoreInteractions.gameObject.SetActive(false);
                }
            }
        }

        private void OnPauseGame()
        {
            mainGameUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            blurEffectCamera.SetActive(true);
        }

        private void OnUnpauseGame()
        {
            mainGameUI.SetActive(true);
            pauseMenuUI.SetActive(false);
            blurEffectCamera.SetActive(false);

        }


    }

}