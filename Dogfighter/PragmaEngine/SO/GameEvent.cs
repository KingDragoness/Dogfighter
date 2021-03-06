using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace Pragma
{

    [CreateAssetMenu(fileName = "OnSomethingHappen", menuName = "Pragma/GameEvent", order = 1)]
    public class GameEvent : ScriptableObject
    {
       
        private List<GameEventListener> listeners =
        new List<GameEventListener>();

        [Button("Raise")]
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        { listeners.Add(listener); }

        public void UnregisterListener(GameEventListener listener)
        { listeners.Remove(listener); }
    }

}
