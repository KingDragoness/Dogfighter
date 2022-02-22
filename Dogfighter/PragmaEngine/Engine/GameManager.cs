using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtilities;

namespace Pragma
{
    /// <summary>
    /// [GameManager]
    /// is the core engine of the game, handles the load in main menu, save system, etc
    /// 
    /// 
    /// </summary>
    public class GameManager : PersistentSingletonMonoBehaviour<GameManager>
    {
        public const string SCENE_CORE = "Core";
        public const string SCENE_MAINMENU = "MainMenu";

        [SerializeField]
        private LevelGameManager levelGameManager;


        //Core scene will loaded and always be loaded.
        //Gameplay loaded by LocalManager.
        //Mainmenu is just a level but important.


        public int point = 0;

        protected override void OnPersistentSingletonAwake()
        {
            base.OnPersistentSingletonAwake();
            LocalManager.GetAnyLocalManager();
            LevelGameManager.CheckLoadedScenes();
            if (levelGameManager.allLoadedGameLevelScenes.Contains("Core") == false) LevelGameManager.LoadSpecialScene(SpecialSceneType.Core);

            if (LocalManager.AllScenesLoaded.Count == 0)
            {
                LaunchMainMenu();
            }


        }

        public virtual void SaveGame(string path = "")
        {

        }

        public virtual void LoadGame()
        {

        }

        //Launch main menu if there's no LocalManager/scene loaded
        private void LaunchMainMenu()
        {
            LevelGameManager.LoadLevelAdditive(SCENE_MAINMENU);
        }

   


    }

}
