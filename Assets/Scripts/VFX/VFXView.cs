using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        private ParticleSystem vfx;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(Vector2 positionToSet)
        {
            gameObject.SetActive(true);
            transform.position = positionToSet;
            vfx = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (vfx != null && vfx.isStopped)
            {
                gameObject.SetActive(false);
                GameService.Instance.GetVFXService().ReturnVFXToPool(controller);
            }
                    
        }
    }
}