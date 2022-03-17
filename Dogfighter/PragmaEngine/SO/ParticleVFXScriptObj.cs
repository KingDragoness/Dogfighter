using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{

    [System.Serializable]
    public class ParticleObject
    {
        public GameObject particle;
        public string ID = "";
    }

    [CreateAssetMenu(fileName = "Explosion", menuName = "Pragma/Particle VFX", order = 1)]
    public class ParticleVFXScriptObj : ScriptableObject
    {

        public List<ParticleObject> ParticleCollections = new List<ParticleObject>();

        public ParticleObject GetParticleObject(string ID)
        {
            return ParticleCollections.Find(x => x.ID == ID);
        }

    }
}