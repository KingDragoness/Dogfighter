using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace Pragma
{

    [System.Serializable]
    public class InteractCommand 
    {
        public string CommandID = "buy";
        [FoldoutGroup("Details")] public UnityEvent UnityEvent;
        [FoldoutGroup("Details")] public bool showCommand = true;
        [FoldoutGroup("Details")] public string CommandDisplay = "Buy (20 MLC)";
    }

    //Index 0 is always default

    public class CommandContainer : MonoBehaviour
    {

        [SerializeField]
        public List<InteractCommand> InteractCommands = new List<InteractCommand>();



    }

}