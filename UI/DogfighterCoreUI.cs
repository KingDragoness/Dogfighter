using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class DogfighterCoreUI : MonoBehaviour
    {
        public Slider sliderLoading;
        public GameObject loadingScreen;
        public GameObject DeveloperConsole;

        [Header("Devconsole")]
        public RectTransform Transform_RuntimeHierarchy;
        public RectTransform Transform_RuntimeInspector;

        [SerializeField]
        private EventSystem eventSystem;

        private void Awake()
        {
            GlobalEngineEvents.OnLoadingLevel += GlobalEngineEvents_OnLoadingLevel;
            GlobalEngineEvents.OnFinishedLoadingLevel += GlobalEngineEvents_OnFinishedLoadingLevel;
        }

        private void GlobalEngineEvents_OnFinishedLoadingLevel()
        {
            loadingScreen.gameObject.SetActive(false);
        }

        private void GlobalEngineEvents_OnLoadingLevel()
        {
            loadingScreen.gameObject.SetActive(true);
        }

        public void DeselectMonitor()
        {
            eventSystem.SetSelectedGameObject(null);
        }

        private void Update()
        {
            sliderLoading.value = LevelGameManager.CurrentLoadingProgress;

            if (Input.GetKeyUp(KeyCode.BackQuote))
            {
                DeveloperConsole.SetActive(!DeveloperConsole.activeSelf);
            }
        }

        private void ResetDevInspectors()
        {
            {
                Vector2 size_RuntimeHierarchy = Transform_RuntimeHierarchy.sizeDelta;

                if (Transform_RuntimeHierarchy.sizeDelta.y < 200)
                {
                    size_RuntimeHierarchy.y = 600;
                }
                if (Transform_RuntimeHierarchy.sizeDelta.x < 200)
                {
                    size_RuntimeHierarchy.x = 250;
                }
            }

            {
                Vector2 size_RuntimeInspector = Transform_RuntimeInspector.sizeDelta;

                if (Transform_RuntimeInspector.sizeDelta.y < 200)
                {
                    size_RuntimeInspector.y = 600;
                }
                if (Transform_RuntimeInspector.sizeDelta.x < 200)
                {
                    size_RuntimeInspector.x = 320;
                }
            }
        }
    }
}