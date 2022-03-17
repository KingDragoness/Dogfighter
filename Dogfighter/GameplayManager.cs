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

        private PragmaClass.Gamemode gamemode;

        public PragmaClass.Gamemode Gamemode
        {
            get { return gamemode; }
        }


        [Space]
        [Header("Interactables")]



        //Static variables
        private static bool isPaused = false;
        public static bool IsPaused { get => isPaused;}

        public static MyCharacterController Player { get => instance.player; set => instance.player = value; }


        private static GameplayManager instance;

        private void Awake()
        {
            instance = this;
            GlobalEngineEvents.OnChangeGamemode += OnChangeGamemode;
            InputEvents.InputFreeLook += InputEvents_InputFreeLook;
        }

        private void OnDestroy()
        {
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

                if (IsPaused)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
            else
            {

            }

            if (gamemode == PragmaClass.Gamemode.Noclip)
            {
                if (IsPaused)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
            else
            {

            }

            if (gamemode == PragmaClass.Gamemode.Offcamera)
            {
                if (player.gameObject.activeSelf == true) player.gameObject.SetActive(false);

                if (IsPaused)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
            else
            {

            }

            if (gamemode == PragmaClass.Gamemode.InteractUI)
            {
                if (player.gameObject.activeSelf == true) player.gameObject.SetActive(false);

                Time.timeScale = 0;
            }
            else
            {

            }
        }

        #endregion


    }
}