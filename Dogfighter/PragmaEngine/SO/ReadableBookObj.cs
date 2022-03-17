using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pragma
{
    [CreateAssetMenu(fileName = "Theory of Fundamentals", menuName = "Pragma/Readable Book", order = 1)]

    public class ReadableBookObj : ScriptableObject
    {

        public List<Sprite> paperSprites = new List<Sprite>();

    }
}