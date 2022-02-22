using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pragma;

namespace Dogfighter
{

    public class DogfightEngineSettings : MonoBehaviour
    {

        public static float SFX_VOLUME = 0.5f;
        public static float MUSIC_VOLUME = 0.5f;
        public static int VSYNC = 0;

        private static DogfightEngineSettings instance;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            OverrideSettings();
        }

        public void OverrideSettings()
        {
            LoadPrefs();
            RefreshGameSettings();
        }

        private static void LoadPrefs()
        {
            SFX_VOLUME = AssignValuePref("SETTINGS.SFX_VOLUME", 1); //PlayerPrefs.GetFloat("");
            MUSIC_VOLUME = AssignValuePref("SETTINGS.MUSIC_VOLUME", 1); //PlayerPrefs.GetFloat("SETTINGS.MUSIC_VOLUME");
            VSYNC = PlayerPrefs.GetInt("SETTINGS.VSYNC");

        }

        public static void SavePrefs()
        {
            PlayerPrefs.SetFloat("SETTINGS.SFX_VOLUME", DogfightEngineSettings.SFX_VOLUME);
            PlayerPrefs.SetFloat("SETTINGS.MUSIC_VOLUME", DogfightEngineSettings.MUSIC_VOLUME);
            PlayerPrefs.SetInt("SETTINGS.VSYNC", DogfightEngineSettings.VSYNC);

        }

        public static void RefreshGameSettings()
        {

            SoundManager.Sfx_Mixer.audioMixer.SetFloat("Master", Mathf.Log10(DogfightEngineSettings.SFX_VOLUME) * 20);
            SoundManager.Music_Mixer.audioMixer.SetFloat("Master", Mathf.Log10(DogfightEngineSettings.MUSIC_VOLUME) * 20);

        }


        private static float AssignValuePref(string KeyName, float defaultValue)
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                return PlayerPrefs.GetFloat(KeyName);
            }
            else
            {
                return defaultValue;
            }
        }

        public bool IntToBool(int a)
        {
            if (a == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}