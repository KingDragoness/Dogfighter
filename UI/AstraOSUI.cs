using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class AstraOSUI : MonoBehaviour
    {

        public List<PauseMenu_PanelSectionUI> panelSectionUI;

        public void OpenUI(PauseMenu_PanelSectionUI.SectionType sectionType)
        {
            var panelMenu = panelSectionUI.Find(x => x.typeMenu == sectionType);

            if (panelMenu == null) return;

            foreach(var panelMenu1 in panelSectionUI)
            {
                panelMenu1.gameObject.SetActive(false);
            }

            panelMenu.gameObject.SetActive(true);

        }

        public void QuitToMenu()
        {
            LevelGameManager.LoadLevelAdditive(1);
        }

    }
}