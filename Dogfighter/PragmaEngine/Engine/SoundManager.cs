using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtilities;
using UnityEngine.Audio;

namespace Pragma
{

    public class SoundManager : MonoBehaviour
    {

        [SerializeField]
        private SoundCollectionsScriptObj soundCollectionsScriptObj;

        [SerializeField]
        private AudioMixerGroup music_Mixer;

        [SerializeField]
        private AudioMixerGroup sfx_Mixer;

        public static SoundCollectionsScriptObj SoundCollectionsScriptObj { get => instance.soundCollectionsScriptObj; set => instance.soundCollectionsScriptObj = value; }
        public static AudioMixerGroup Music_Mixer { get => instance.music_Mixer; set => instance.music_Mixer = value; }
        public static AudioMixerGroup Sfx_Mixer { get => instance.sfx_Mixer; set => instance.sfx_Mixer = value; }

        private static SoundManager instance;

        private void Awake()
        {
            instance = this;
        }
    }
}