using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dogfighter
{

    public class CockpitHUD_CompassLabelButton : MonoBehaviour
    {

        public enum TypeMarker
        {
            N,
            S,
            W,
            E,
            NW,
            NE,
            SW,
            SE,
            Objective
        }

        public Text textCompass;
        public RectTransform rectTransform;
        public TypeMarker direction;
    }
}