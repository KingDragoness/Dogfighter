using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pragma;

namespace Dogfighter
{
    public class GenericButton : MonoBehaviour
    {
        
        public GameEvent highlightButtonEvent;

        public void HighlightButton()
        {
            highlightButtonEvent.Raise();
        }

    }
}