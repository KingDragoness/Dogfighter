using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtilities;

namespace Pragma
{

    public class ScriptUpdatorManager : MonoBehaviour
    {

        public delegate void onUpdate();
        public static event onUpdate OnUpdate;


        private void Update()
        {
            OnUpdate?.Invoke();
        }

    }

}
