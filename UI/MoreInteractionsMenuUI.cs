using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;
using UnityUtilities;

namespace Dogfighter
{
    public class MoreInteractionsMenuUI : MonoBehaviour
    {

        public List<MoreInteractButton> AllMoreInteractButtons = new List<MoreInteractButton>();
        public Transform parentLayoutSpace;
        public MoreInteractButton templateButton;
        public GridLayoutGroup GridLayoutGroup;

        private Countdown countdownLoop;
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            InputEvents.InputFreeLook += InputEvents_InputFreeLook;
        }

        private void OnDestroy()
        {
            InputEvents.InputFreeLook -= InputEvents_InputFreeLook;
        }

        private void Start()
        {
            countdownLoop = new Countdown(true, 0.1f);
            templateButton.gameObject.SetActive(false);

        }


        #region Input Events

        private void InputEvents_InputFreeLook()
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                RefreshMoreInteractList(true);
                AdjustInteractSize(true);
                bool_LockState = false;
            }
        }

        #endregion

        bool bool_LockState = false;

        private void Update()
        {
            if (Cursor.lockState == CursorLockMode.Locked && countdownLoop.Progress())
            {
                RefreshMoreInteractList(false);
                if (bool_LockState == false) AdjustInteractSize(false);
                bool_LockState = true;

            }
             

        }

        private void AdjustInteractSize(bool fullSize)
        {

            var rt1 = templateButton.GetComponent<RectTransform>();
            var sizeTarget = new Vector2(rectTransform.sizeDelta.x, AllMoreInteractButtons.Count * GridLayoutGroup.cellSize.y);

            if (fullSize)
            {
                sizeTarget += new Vector2(0, GridLayoutGroup.padding.top + GridLayoutGroup.padding.bottom);
                LeanTween.size(rectTransform, sizeTarget, 0.5f);
            }
            else
            {
                sizeTarget = new Vector2(rectTransform.sizeDelta.x, 1 * GridLayoutGroup.cellSize.y);
                sizeTarget += new Vector2(0, GridLayoutGroup.padding.top + GridLayoutGroup.padding.bottom);
                LeanTween.size(rectTransform, sizeTarget, 0.5f);

            }
        }

        private void RefreshMoreInteractList(bool fullSize)
        {
            var Interactable = QuickReferencor.InteractPointer.CurrentInteractable;

            if (Interactable == null)
            {
                return;
            }

            foreach (var button in AllMoreInteractButtons)
            {
                Destroy(button.gameObject);
            }

            AllMoreInteractButtons.Clear();
            var CommandContainer = Interactable.CommandContainer;

            int index = 0;

            foreach (var interacts in CommandContainer.InteractCommands)
            {
                if (fullSize == false && index >= 1)
                {
                    break;
                }

                if (!interacts.showCommand)
                {
                    continue;
                }

                var button1 = Instantiate(templateButton, parentLayoutSpace);

                if (index == 0)
                {
                    button1.labelInteractName.text = $"[F] {interacts.CommandDisplay}";
                }
                else
                {
                    button1.labelInteractName.text = $"{interacts.CommandDisplay}";
                }

                button1.gameObject.SetActive(true);
                button1.interactCommand = interacts;
                AllMoreInteractButtons.Add(button1);
                index++;
            }

        }


        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
    }
}