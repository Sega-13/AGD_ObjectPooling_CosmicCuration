using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        private ParticleSystem vfx;
        [SerializeField] private List<VFXData> particleSystemMap;
        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(VFXType type, Vector2 positionToSet)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = positionToSet;
            foreach(VFXData item in particleSystemMap)
            {
                if(item.type == type)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    vfx = item.particleSystem;
                }
                else
                {
                    item.particleSystem.gameObject.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if (vfx != null && vfx.isStopped)
            {
               vfx.gameObject.SetActive(false);
                vfx = null;
                controller.OnParticleEffectCompleted();
                gameObject.SetActive(false);
            }
                    
        }
        [Serializable]
        public class VFXData
        {
            public VFXType type;
            public ParticleSystem particleSystem;
        }
    }
}