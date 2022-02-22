using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class PauseMenu_SettingsUI : MonoBehaviour
    {

        [FoldoutGroup("Sounds")] public ModularUI_SliderLabelValue Slider_SFX;
        [FoldoutGroup("Sounds")] public ModularUI_SliderLabelValue Slider_Music;


        private void Start()
        {
            Slider_SFX.sliderValue.SetValueWithoutNotify(DogfightEngineSettings.SFX_VOLUME);
            Slider_Music.sliderValue.SetValueWithoutNotify(DogfightEngineSettings.MUSIC_VOLUME);

            RefreshUI();
        }


        public void RefreshUI()
        {
            DogfightEngineSettings.SFX_VOLUME = Slider_SFX.sliderValue.value;
            DogfightEngineSettings.MUSIC_VOLUME = Slider_Music.sliderValue.value;
            DogfightEngineSettings.SavePrefs();


            {
                var sfxValue = (Mathf.Round(Slider_SFX.sliderValue.value * 100) / 100);
                var musicValue = (Mathf.Round(Slider_Music.sliderValue.value * 100) / 100);
                sfxValue *= 100;
                musicValue *= 100;

                Slider_SFX.textValue.text = sfxValue.ToString();
                Slider_Music.textValue.text = musicValue.ToString();
            }

            DogfightEngineSettings.RefreshGameSettings();

        }

  

    }
}