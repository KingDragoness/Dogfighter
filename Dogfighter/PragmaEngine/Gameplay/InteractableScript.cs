using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{

    public interface IOffCamerable
    {
        GameObject VirtualCamera();
    }

    [RequireComponent(typeof(CommandContainer))]
    public abstract class InteractableScript : PragmaScript
    {

        public CommandContainer CommandContainer;

        public virtual void Interact(InteractCommand interactCommand)
        {
            interactCommand.UnityEvent?.Invoke();
        }
        public abstract string GetDescription();

        public virtual void QuickInteract()
        {
            var command1 = GetQuickInteract();

            if (command1 != null)
            {
                Interact(command1);
            }
        }

        public InteractCommand GetQuickInteract()
        {
            if (CommandContainer.InteractCommands.Count == 0)
            {
                return null;
            }

            var command1 = CommandContainer.InteractCommands[0];

            return command1;
        }
    }
}