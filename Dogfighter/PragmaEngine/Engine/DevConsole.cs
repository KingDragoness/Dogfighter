using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityUtilities;

namespace Pragma
{

    public class DevConsole : SingletonMonoBehaviour<DevConsole>
    {
        public InputField inputField;
        public Text consoleText;

        public List<string> commandHistory = new List<string>();
        public int index = 0;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                ExecuteCommand(inputField.text);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                index++;
                HistoryRefresh();
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                index--;
                HistoryRefresh();
            }
        }

        public void HistoryRefresh()
        {
            if (index >= commandHistory.Count)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = commandHistory.Count - 1;
            }

            inputField.text = commandHistory[index];
        }

        public void ExecuteCommand(string command)
        {
            string[] inputSplit = command.Split(' ');

            string commandInput = inputSplit[0];
            string[] args = inputSplit.Skip(0).ToArray();

            SendConsoleMessage("<color=#ffffffcc>" + command + "</color>");

            commandHistory.Add(command);
            GlobalEngineEvents.Invoke_OnCheatCode(args);
        }

        public void SendConsoleMessage(string msg)
        {
            if (consoleText != null) consoleText.text += "> " + msg + "\n";
        }

        public void ClearAll()
        {
            if (consoleText != null) consoleText.text = ">";
        }
    }
}