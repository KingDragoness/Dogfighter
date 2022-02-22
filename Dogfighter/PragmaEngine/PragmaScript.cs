using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{

    public class PragmaScript : MonoBehaviour
    {

        private void Awake()
        {
            ScriptUpdatorManager.OnUpdate += OnPragmaUpdate;
        }

        private void OnDestroy()
        {
            ScriptUpdatorManager.OnUpdate -= OnPragmaUpdate;
        }

        public virtual void OnPragmaUpdate()
        {

        }

    }
}