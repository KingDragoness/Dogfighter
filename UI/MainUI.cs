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
        [Header("Interact UI")]
        [SerializeField]
        private ReadingBookUI readingBookUI;

        [Space]
        public GameObject mainGameUI;
        public GameObject pauseMenuUI;
        public GameObject blurEffectCamera;


        private static MainUI instance;

        public static ReadingBookUI ReadingBookUI { get => instance.readingBookUI; set => instance.readingBookUI = value; }

        private void Awake()
        {
            instance = this;
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


            if (!GameplayManager.IsPaused)
            {
                var currentInteract = QuickReferencor.InteractPointer.CurrentInteractable;

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