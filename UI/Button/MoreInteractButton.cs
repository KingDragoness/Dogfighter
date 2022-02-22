using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class MoreInteractButton : MonoBehaviour
    {

        public Text labelInteractName;
        public InteractCommand interactCommand;

        public void ExecuteInteraction()
        {
            QuickReferencor.InteractPointer.ExecuteCommand(interactCommand);
        }

    }
}