using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dogfighter
{

    public class PauseMenu_PanelSectionUI : MonoBehaviour
    {
        
        public enum SectionType
        {
            AstraOS,
            Airplane,
            Finance,
            Settings,
            Mission,
            Multiverse
        }

        public SectionType typeMenu;

    }
}