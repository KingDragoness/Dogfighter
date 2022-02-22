using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using Sirenix.OdinInspector;
using Newtonsoft.Json;
using Pragma;
using UnityEngine;

namespace Dogfighter
{

    public class DogfighterGameManager : GameManager
    {

        public DogfighterSaveClass SaveClass;

        public static readonly string GameSavePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/Dogfighter/Saves";

        
        public static DogfighterGameManager DogfighterInstance;

        protected override void OnPersistentSingletonAwake()
        {
            base.OnPersistentSingletonAwake();
            DogfighterInstance = this;

            BuildSaveFolder();
            GlobalEngineEvents.OnLoadSave += OnLoadSave;

        }


        protected override void OnSceneSwitched()
        {
            base.OnSceneSwitched();
        }

        private void BuildSaveFolder()
        {
            System.IO.Directory.CreateDirectory(GameSavePath);
        }

        #region Save and Load

        public override void SaveGame(string path = "")
        {
            string pathSave = "";

            if (path == "")
            {
                pathSave = GameSavePath + "/defaultSave.save";
            }

            print(pathSave);

            var saveData = SaveClass;
            PackSave();

            string jsonTypeNameAll = JsonConvert.SerializeObject(saveData, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            File.WriteAllText(pathSave, jsonTypeNameAll);

            if (DevConsole.Instance != null) DevConsole.Instance.SendConsoleMessage($"File has been saved to {pathSave}");
        }

        public override void LoadGame()
        {
            string pathLoad = "";

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            pathLoad = GameSavePath + "/defaultSave.save";

            try
            {
                SaveClass = JsonConvert.DeserializeObject<DogfighterSaveClass>(File.ReadAllText(pathLoad), settings);

                LevelGameManager.LoadLevelAdditive(SaveClass.multiverse.mainLevelName, true);

            }
            catch
            {
                Application.LoadLevel(1);
            }

        }

        public void PackSave()
        {
            //Active level!
            SaveClass.multiverse.mainLevelName = LevelGameManager.GetSceneCurrentName();
            SaveClass.singularVerse.playerPosition = GameplayManager.Player.transform.position;
        }


        private void OnLoadSave()
        {
            GameplayManager.Player.Motor.SetPosition(SaveClass.singularVerse.playerPosition);

        }

        #endregion
    }
}