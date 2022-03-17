using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pragma
{

    public class ParticleManager : MonoBehaviour
    {

        public List<ParticleVFXScriptObj> allParticleVFX = new List<ParticleVFXScriptObj>();

        private static ParticleManager instance;

        private void Awake()
        {
            instance = this;
        }

        public static GameObject SpawnParticle(string ID, Vector3 position = new Vector3())
        {
            ParticleObject particleTemplate = null;

            foreach (var particleList in instance.allParticleVFX)
            {
                var po = particleList.ParticleCollections.Find(x => x.ID == ID);

                if (po != null)
                {
                    particleTemplate = po;
                    break;
                }
            }

            if (particleTemplate != null)
            {
                var particle1 = Instantiate(particleTemplate.particle, position, Quaternion.identity);

                return particle1;
            }
            else
            {
                return null;
            }
        }

    }
}