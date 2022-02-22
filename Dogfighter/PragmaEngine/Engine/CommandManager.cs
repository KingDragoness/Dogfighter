using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dogfighter;

namespace Pragma
{
    public class CommandManager : MonoBehaviour
    {

        public delegate void Command(string[] args); // declare a delegate


        public class GameCommand
        {

            public Command command1 = null;
            public string errorMessage = "";
            public string commandName = "";
        }

        #region All Commands

        public class AllGameCommands
        {


            public static List<GameCommand> DogfighterGameCommand = new List<GameCommand>()
            {
                new GameCommand 
                { 
                    commandName = "savegame" , 
                    command1 = Command_SaveGame, 
                    errorMessage = "Invalid argument! savegame" 
                }
                ,
                new GameCommand 
                {
                    commandName = "loadgame" ,
                    command1 = Command_LoadGame,
                    errorMessage = "Invalid argument! loadgame"
                }
                ,
                new GameCommand
                {
                    commandName = "addpoint" ,
                    command1 = Command_AddPoint,
                    errorMessage = "Invalid argument! addpoint [int point]"
                }
                ,
                new GameCommand
                {
                    commandName = "mainmenu" ,
                    command1 = Command_GoToMainMenu,
                    errorMessage = "Invalid argument! mainmenu"
                }
                ,
                new GameCommand
                {
                    commandName = "loadlevel" ,
                    command1 = Command_LoadLevel,
                    errorMessage = "Invalid argument! loadlevel [int level]"
                }
                ,
                new GameCommand
                {
                    commandName = "ui" ,
                    command1 = Command_ChangeGamemode,
                    errorMessage = "Invalid argument! ui [0 = firstperson, 1 = offcamera, 2 = noclip]"
                }
            };

            public static GameCommand GetCommand(string commandName)
            {
                GameCommand gameCommand = null;

                gameCommand = DogfighterGameCommand.Find(x => x.commandName == commandName);

                return gameCommand;
            }


            public static List<string> GetHelpList(string index = "0")
            {
                List<string> helpLists = new List<string>();

                helpLists.Add("'mainmenu' go to main menu.");
                helpLists.Add("'loadlevel' to loadlevel by index.");
                helpLists.Add("'addpoint' (debug only) adds point to GameManager.");
                helpLists.Add("'ui' to change modes.");
                helpLists.Add("'clear' to wipe console.");
                helpLists.Add("'savegame' to save game.");
                helpLists.Add("'loadgame' to load game.");

                return helpLists;
            }


            private static void Command_AddPoint(string[] args)
            {
                int point = 0;
                bool success = int.TryParse(args[1], out point);

                if (success == false)
                {
                    throw new System.Exception("Parse failed!");
                }

                GameManager.Instance.point += point;
            }

            private static void Command_LoadLevel(string[] args)
            {
                int levelIndex = 0;
                bool success = int.TryParse(args[1], out levelIndex);

                if (success == false)
                {
                    throw new System.Exception("Parse failed!");
                }

                LevelGameManager.LoadLevelAdditive(levelIndex);
            }

            private static void Command_GoToMainMenu(string[] args)
            {
                LevelGameManager.LoadLevelAdditive(GameManager.SCENE_MAINMENU);
            }

            private static void Command_SaveGame(string[] args)
            {
                GameManager.Instance.SaveGame();
            }

            private static void Command_LoadGame(string[] args)
            {
                GameManager.Instance.LoadGame();
            }

            private static void Command_ChangeGamemode(string[] args)
            {
                int index = 0;

                bool success = int.TryParse(args[1], out index);

                if (success == false)
                {
                    throw new System.Exception("Parse failed!");
                }

                PragmaClass.Gamemode gamemode1 = (PragmaClass.Gamemode)index;
                GameplayManager.ChangeGamemode(gamemode1);
            }

        }


        #endregion




        private void Awake()
        {
            GlobalEngineEvents.OnCheatCode += GlobalEngineEvents_OnCheatCode;
        }

        private void OnDestroy()
        {
            GlobalEngineEvents.OnCheatCode -= GlobalEngineEvents_OnCheatCode;
        }

        private bool GlobalEngineEvents_OnCheatCode(string[] args)
        {
            if (args.Length == 0)
            {
                return false;
            }

            string commandName = args[0];
            string errorReturn = "Command not found!";

            if (commandName != "help" && commandName != "clear")
            {
                try
                {
                    GameCommand gameCommand = AllGameCommands.GetCommand(commandName);
                    errorReturn = gameCommand.errorMessage;
                    gameCommand.command1?.Invoke(args);
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e.StackTrace);
                    DevConsole.Instance.SendConsoleMessage($"<color=#ACACAC>{errorReturn}</color>");
                    return false;
                }
            }
            else if (commandName == "help")
            {
                if (args.Length >= 2)
                {
                    foreach (var str in AllGameCommands.GetHelpList(args[1]))
                    {
                        DevConsole.Instance.SendConsoleMessage(str);
                    }
                }
                else
                {
                    foreach (var str in AllGameCommands.GetHelpList())
                    {
                        DevConsole.Instance.SendConsoleMessage(str);
                    }
                }
            }
            else if (commandName == "clear")
            {
                DevConsole.Instance.ClearAll();
            }


            return true;
        }

    }

}

