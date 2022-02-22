using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtilities;
using Pragma;

namespace Dogfighter
{
    [System.Serializable]
    public class DogfighterSaveClass
    {

        [System.Serializable]
        public class Singularverse
        {
            public bool introExecuted = false;
            public Vector3 playerPosition;
        }

        [System.Serializable]
        public class Multiverse
        {
            public string playerName = "Dogger";
            public string mainLevelName;
        }


        public Singularverse singularVerse;
        public Multiverse multiverse;


    }
}