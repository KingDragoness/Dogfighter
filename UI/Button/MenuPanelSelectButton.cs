using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dogfighter.PauseMenu_PanelSectionUI;

namespace Dogfighter
{

    public class MenuPanelSelectButton : MonoBehaviour
    {

        public AstraOSUI astraOSUI;
        public SectionType typeMenu;

        public void Open()
        {
            astraOSUI.OpenUI(typeMenu);
        }

    }
}