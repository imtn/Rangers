using UnityEngine;

namespace Assets.Scripts.Util
{
	public class AnimationInfo : MonoBehaviour
	{
        // Speed of the animator to save
		private float speed = 0f;

        // Reference to the animator
        private Animator anim;

		void OnEnable()
		{
			//Data.GameManager.GamePause += PauseAnimator;
			//Data.GameManager.GameUnpause += UnpauseAnimator;
		}
		void OnDisable()
		{
			//Data.GameManager.GamePause -= PauseAnimator;
			//Data.GameManager.GameUnpause -= UnpauseAnimator;
		}

        // Initialize
        void Start()
        {
            anim = GetComponent<Animator>();
        }
		
		public void PauseAnimator()
		{
			speed = anim.speed;
			anim.speed = 0;
		}
		
		public void UnpauseAnimator()
		{
			anim.speed = speed;
		}
	}
}
