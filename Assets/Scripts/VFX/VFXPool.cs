using CosmicCuration.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vFXView;
        private VFXData vFXData;

        public VFXPool(VFXView vFXView)
        {
            this.vFXView = vFXView;
        }
        public VFXController GetVFX() => GetItem<VFXController>();
        protected override VFXController CreateItem<T>() => new VFXController(vFXView);
      

    }

}
