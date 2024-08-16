using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
       // private List<VFXData> vfxData = new List<VFXData>();
        private VFXPool vfxPool;

        public VFXService(VFXView vFXView) => vfxPool = new VFXPool(vFXView);

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vfxPool.GetVFX();
            vfxToPlay.Configure(type, spawnPosition);
        }
        public void ReturnVFXToPool(VFXController vfxToReturn) => vfxPool.ReturnItem(vfxToReturn);
    } 
}