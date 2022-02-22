using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtilities;

namespace Dogfighter
{

    public class QuickReferencor : SingletonMonoBehaviour<QuickReferencor>
    {
        [SerializeField]
        private InteractPointer interactPointer;
        [SerializeField]
        private Camera mainCamera;

        public static InteractPointer InteractPointer { get => Instance.interactPointer; set => Instance.interactPointer = value; }
        public static Camera MainCamera { get => Instance.mainCamera; set => Instance.mainCamera = value; }

    }
}