using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerMovement : PlayerControllerObject
	{
        public override void Run()
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Vertical"), 0) * Time.deltaTime * 3);
        }
		
		public override void FixedRun()
		{
			
		}
	}
}
