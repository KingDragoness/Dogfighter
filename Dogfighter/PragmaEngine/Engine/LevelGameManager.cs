using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtilities;

namespace Pragma
{
    public enum SpecialSceneType
    {
        Core,
        Gameplay
    }

    public class LevelGameManager : MonoBehaviour
    {

        public List<string> allLoadedGameLevelScenes = new List<string>();
        private float currentLoadingProgress = 0f;


        private string currentGameLevel = "";

        private static LevelGameManager instance;

        public static float CurrentLoadingProgress { get => instance.currentLoadingProgress; set => instance.currentLoadingProgress = value; }

        private void Awake()
        {
            instance = this;
        }


        public static void CheckLoadedScenes()
        {
            instance.allLoadedGameLevelScenes.Clear();
            int countLoaded = SceneManager.sceneCount;
            Scene[] loadedScenes = new Scene[countLoaded];

            for (int i = 0; i < countLoaded; i++)
            {
                loadedScenes[i] = SceneManager.GetSceneAt(i);
            }

            foreach(var scene in loadedScenes)
            {
                instance.allLoadedGameLevelScenes.Add(scene.name);
            }
        }

        public static string GetSceneCurrentName()
        {
            var scene = SceneManager.GetActiveScene();
            return scene.name;
        }

        public static void LoadSpecialScene(SpecialSceneType specialScene)
        {
            instance.LoadSpecialScene1(specialScene);
        }

        public static void LoadLevelAdditive(string sceneName, bool loadFromSave = false)
        {
            instance.LoadLevelAdditive1(sceneName, loadFromSave);
        }

        public static void LoadLevelAdditive(int sceneIndex)
        {
            instance.LoadLevelAdditive1(sceneIndex);
        }

        public async void LoadSpecialScene1(SpecialSceneType specialScene)
        {

            try
            {
                var sceneCurrent = SceneManager.UnloadSceneAsync(instance.currentGameLevel);
            }
            catch
            {

            }

            var scene = SceneManager.LoadSceneAsync(specialScene.ToString(), LoadSceneMode.Additive);
            scene.allowSceneActivation = false;

            do
            {
                await Task.Delay(100);

            }
            while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;
            CheckLoadedScenes();

        }

        public async void LoadLevelAdditive1(string sceneName, bool loadFromSave = false)
        {
            GlobalEngineEvents.Invoke_OnLoadingLevel();

            CheckLoadedScenes();
            foreach (var levelScene in instance.allLoadedGameLevelScenes)
            {
                if (levelScene == GameManager.SCENE_CORE)
                {
                    continue;
                }

                try
                {
                    var sceneCurrent = SceneManager.UnloadSceneAsync(levelScene);
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e.StackTrace);
                }

            }

            var scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            scene.allowSceneActivation = false;

            do
            {
                await Task.Delay(100);
                instance.currentLoadingProgress = scene.progress;
            }
            while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;

            while (!scene.isDone)
            {
                await Task.Delay(100);
            }

            try
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
                instance.currentGameLevel = sceneName;
                CheckLoadedScenes();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.StackTrace);
            }

            GlobalEngineEvents.Invoke_OnFinishedLoadingLevel();
            if (loadFromSave) GlobalEngineEvents.Invoke_OnLoadSave();
        }

        public async void LoadLevelAdditive1(int sceneIndex)
        {
            if (sceneIndex == 0)
            {
                return;
            }

            GlobalEngineEvents.Invoke_OnLoadingLevel();

            CheckLoadedScenes();
            Debug.Log($"{instance.allLoadedGameLevelScenes.Count}");

            foreach (var levelScene in instance.allLoadedGameLevelScenes)
            {
                if (levelScene == GameManager.SCENE_CORE)
                {
                    continue;
                }

                try
                {
                    Debug.Log($"Unload: {levelScene}");
                    var sceneCurrent = SceneManager.UnloadSceneAsync(levelScene);
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e.StackTrace);
                }

            }

            var scene = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            scene.allowSceneActivation = false;

            do
            {
                await Task.Delay(100);
                instance.currentLoadingProgress = scene.progress;
            }
            while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;

            while (!scene.isDone)
            {
                await Task.Delay(100);
            }

            Debug.Log("test 90101");
            try
            {
                var scene1 = SceneManager.GetSceneByBuildIndex(sceneIndex);
                SceneManager.SetActiveScene(scene1);
                instance.currentGameLevel = scene1.name;
                CheckLoadedScenes();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.StackTrace);
            }
            GlobalEngineEvents.Invoke_OnFinishedLoadingLevel();

        }


    }
}