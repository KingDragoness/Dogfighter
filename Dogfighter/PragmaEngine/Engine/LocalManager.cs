using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace Pragma
{

    /// <summary>
    /// [LocalManager]
    /// Exists in every level scenes (Not special scenes), ensures the scene load properly 
    /// 
    /// 
    /// </summary>

    public class LocalManager : MonoBehaviour
    {

        [System.Serializable]
        public class LevelCommand
        {
            [FoldoutGroup("Show more")] public UnityEvent OnCommandExecute;
            [FoldoutGroup("Show more")] public string commandName = "test";
            [FoldoutGroup("Show more")] public string commandHelp = "'test' this is only for test";
        }

        public List<LevelCommand> AllLocalCommands = new List<LevelCommand>();
        public string LevelName = "Beginnings";

        [Space]
        public List<string> sceneDependencies = new List<string>();
        public bool isGameLevel = false;
        public static List<LocalManager> AllScenesLoaded = new List<LocalManager>();


        #region Manager

        public static void GetAnyLocalManager()
        {
            LocalManager[] localManagers = FindObjectsOfType<LocalManager>();
            
            foreach(var localManager in localManagers)
            {
                localManager.RegisterManager();
            }
        }

        public void Awake()
        {
            GlobalEngineEvents.OnCheatCode += OnExecuteCommand;
            RegisterManager();
        }

        private void OnDestroy()
        {
            UnregisterManager();
        }

        private void RegisterManager()
        {
            if (AllScenesLoaded.Contains(this) == false)
            {
                AllScenesLoaded.Add(this);
            }
        }

        private void UnregisterManager()
        {
            if (AllScenesLoaded.Contains(this) == true)
            {
                AllScenesLoaded.Remove(this);
            }
        }


        private bool OnExecuteCommand(string[] args)
        {
            bool success = false;

            if (args[0] == "help" && args.Length != 0)
            {
                if (args[0] == "level")
                    Help();

                success = true;
            }

            foreach (var command in AllLocalCommands)
            {
                if (command.commandName == args[0])
                {
                    command.OnCommandExecute?.Invoke();
                    success = true;
                    break;
                }
            }


            return success;
        }

        private void Help()
        {
            List<string> helps = new List<string>();
            helps.Add($" =============== {LevelName.ToUpper()} COMMANDS =============== ");

            foreach (var localCommand in AllLocalCommands)
            {
                helps.Add(localCommand.commandHelp);
            }

            foreach (var helpString in helps)
            {
                DevConsole.Instance.SendConsoleMessage(helpString);
            }

            helps.Add("");
        }
        #endregion

        private void StartupScene()
        {

        }

        public void LoadLevel(string levelName)
        {
            LevelGameManager.LoadLevelAdditive(levelName);
        }

    }
}