using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;
    }


    [CreateAssetMenu(fileName = "Sound Collection", menuName = "Pragma/SoundCollectionsScriptObj", order = 1)]
    public class SoundCollectionsScriptObj : ScriptableObject
    {

        public List<Sound> sounds = new List<Sound>();


    }
}