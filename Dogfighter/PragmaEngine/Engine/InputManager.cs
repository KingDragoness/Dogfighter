using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{

    public static class InputEvents
    {
        public delegate void inputFreeLook();
        public static event inputFreeLook InputFreeLook;

        internal static void Invoke_InputFreeLook()
        {
            InputFreeLook?.Invoke();
        }
    }

    public class InputManager : MonoBehaviour
    {

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                InputEvents.Invoke_InputFreeLook();
            }
        }


    }

}