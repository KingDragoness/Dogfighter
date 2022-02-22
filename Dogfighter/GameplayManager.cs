using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtilities;
using Sirenix.OdinInspector;
using KinematicCharacterController;
using Pragma;

namespace Dogfighter
{

    //GameplayManager
    //Handle pause, unpause and gamemode states

    public class GameplayManager : MonoBehaviour
    {

        [Header("Core Gameplay")]
        [SerializeField]
        private MyCharacterController player;
        public IOffCamerable currentOffCamerable;

        private PragmaClass.Gamemode gamemode;

        public PragmaClass.Gamemode Gamemode
        {
            get { return gamemode; }
        }


        [Space]
        [Header("Interactables")]



        //Static variables
        public static bool isPaused = false;
        public static MyCharacterController Player { get => instance.player; set => instance.player = value; }


        private static GameplayManager instance;

        private void Awake()
        {
            instance = this;
            GlobalEngineEvents.OnPauseGame += OnPauseGame;
            GlobalEngineEvents.OnUnpauseGame += OnUnpauseGame;
            GlobalEngineEvents.OnChangeGamemode += OnChangeGamemode;
            InputEvents.InputFreeLook += InputEvents_InputFreeLook;
        }

        private void OnDestroy()
        {
            GlobalEngineEvents.OnPauseGame -= OnPauseGame;
            GlobalEngineEvents.OnUnpauseGame -= OnUnpauseGame;
            GlobalEngineEvents.OnChangeGamemode -= OnChangeGamemode;
            InputEvents.InputFreeLook -= InputEvents_InputFreeLook;

        }

        #region Event-driven

        private static void InputEvents_InputFreeLook()
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }


        public static void ChangeGamemode(PragmaClass.Gamemode gamemode1)
        {
            instance.gamemode = gamemode1;
            GlobalEngineEvents.Invoke_OnChangeGamemode(gamemode1);
        }

        private static void OnChangeGamemode(PragmaClass.Gamemode gamemode1)
        {
            
        }

        #endregion

        #region Pause/unpause

        private static void OnPauseGame()
        {
            Time.timeScale = 0;
        }

        private static void OnUnpauseGame()
        {
            Time.timeScale = 1;
        }

        public static void TogglePause()
        {
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                GlobalEngineEvents.Invoke_OnPauseGame();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                GlobalEngineEvents.Invoke_OnUnpauseGame();
            }
        }

        #endregion

        #region Update

        private void Update()
        {
            InputGame();
            RunGamemode();
        }

        private void InputGame()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                isPaused = !isPaused;
                TogglePause();
            }

        }

        private void RunGamemode()
        {
            if (gamemode == PragmaClass.Gamemode.FirstPerson)
            {
                if (player.gameObject.activeSelf == false) player.gameObject.SetActive(true);
            }
            else
            {

            }

            if (gamemode == PragmaClass.Gamemode.Noclip)
            {

            }
            else
            {

            }

            if (gamemode == PragmaClass.Gamemode.Offcamera)
            {
                if (player.gameObject.activeSelf == true) player.gameObject.SetActive(false);

                if (currentOffCamerable != null)
                {
                    var virtualCam = currentOffCamerable.VirtualCamera();

                    if (virtualCam.activeSelf == false) virtualCam.SetActive(true);
                }
            }
            else
            {
                if (currentOffCamerable != null)
                {
                    var virtualCam = currentOffCamerable.VirtualCamera();

                    if (virtualCam.activeSelf == true) virtualCam.SetActive(false);
                }

            }
        }

        #endregion

        public static void SetOffCamerable(IOffCamerable offCamerable)
        {
            instance.currentOffCamerable = offCamerable;
        }

    }
}