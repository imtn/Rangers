using UnityEngine;

namespace Assets.Scripts.Util
{
	public class ParticleSystemInfo : MonoBehaviour
	{
        // Reference to the particle system
        private ParticleSystem system;

		void OnEnable()
		{
			//Data.GameManager.GamePause += PauseParticles;
			//Data.GameManager.GameUnpause += UnpauseParticles;
		}
		void OnDisable()
		{
			//Data.GameManager.GamePause -= PauseParticles;
			//Data.GameManager.GameUnpause -= UnpauseParticles;
		}

        // Initialize
        void Start()
        {
            system = GetComponent<ParticleSystem>();
        }

		public void PauseParticles()
		{
			system.Pause();
		}

		public void UnpauseParticles()
		{
            system.Play();
		}
	}
}
