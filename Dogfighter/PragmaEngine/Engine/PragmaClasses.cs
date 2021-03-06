using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{

    public class PragmaClass
    {
        public enum Gamemode
        {
            FirstPerson = 0,    //Default player mode
            Offcamera = 1,      //During playing games, interact screen objects, using spaceship, etc 
            InteractUI = 2,    //During interact overlay hud mode
            Noclip = 3
        }

    }
}