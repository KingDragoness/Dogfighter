using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{
    /// <summary>
    /// BaseInteractUI used for UI that pauses & full screen.
    /// </summary>

    public abstract class BaseInteractUI : MonoBehaviour
    {
        
        public virtual void ExitUI()
        {
            gameObject.SetActive(false);
            GameplayManager.ChangeGamemode(PragmaClass.Gamemode.FirstPerson);
        }

    }
}