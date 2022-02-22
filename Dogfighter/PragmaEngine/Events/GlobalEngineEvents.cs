using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{
    public static class GlobalEngineEvents
    {

        #region Events

        public delegate void onLoadingLevel();
        public static event onLoadingLevel OnLoadingLevel;

        public delegate void onFinishedLoadingLevel();
        public static event onFinishedLoadingLevel OnFinishedLoadingLevel;

        public delegate void onChangeGamemode(PragmaClass.Gamemode gamemode1);
        public static event onChangeGamemode OnChangeGamemode;

        public delegate void onLoadSave();
        public static event onLoadSave OnLoadSave;

        public delegate void onPauseGame();
        public static event onPauseGame OnPauseGame;

        public delegate void onUnpauseGame();
        public static event onUnpauseGame OnUnpauseGame;

        public delegate bool onCheatCode(string[] args);
        public static event onCheatCode OnCheatCode;

        #endregion

        public static void Invoke_OnPauseGame()
        {
            OnPauseGame?.Invoke();
        }

        public static void Invoke_OnUnpauseGame()
        {
            OnUnpauseGame?.Invoke();
        }

        public static void Invoke_OnChangeGamemode(PragmaClass.Gamemode gamemode1)
        {
            OnChangeGamemode?.Invoke(gamemode1);
        }

        internal static void Invoke_OnLoadingLevel()
        {
            OnLoadingLevel?.Invoke();
        }

        internal static void Invoke_OnFinishedLoadingLevel()
        {
            OnFinishedLoadingLevel?.Invoke();
        }

        internal static void Invoke_OnLoadSave()
        {
            OnLoadSave?.Invoke();
        }

        internal static void Invoke_OnCheatCode(string[] args)
        {
            OnCheatCode?.Invoke(args);
        }

        //EXTENSION! Next time implement!

        //public static float GetX(this Vector3 vector3)
        //{
        //    return vector3.x;
        //}
    }
}