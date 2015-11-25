using UnityEngine;

/*
 * This class wil manage all the player's components,
 * such as movement, data , etc
 */
namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		//componenets to manage
		private PlayerMovement movement;
		private PlayerData data;
		private PlayerAttack attack;

		void Start()
		{
			//init all componenets
			InitializePlayerComponents();
		}
		void Update()
		{
			//run all components
			//data.Run();
			movement.Run();
			attack.Run();
		}

		void FixedUpdate()
		{
			//run all fixed components for physics
			movement.FixedRun();
		}

		//assigning references
		private void InitializePlayerComponents()
		{
			//get all components to manage
			//data = GetComponent<PlayerData>();
			movement = GetComponent<PlayerMovement>();
			attack = GetComponent<PlayerAttack>();

            //tell all components this is their controller
            //data.Controller = this;
            movement.Controller = this;
            attack.Controller = this;
		}

		public PlayerAttack AttackComponent
		{
			get { return attack; }
		}
		public PlayerData DataComponent
		{
			get { return data; }
		}
		public PlayerMovement MovementComponent
		{
			get { return movement; }
		}
	}
}
