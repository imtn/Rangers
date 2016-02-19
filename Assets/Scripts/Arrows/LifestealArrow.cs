using UnityEngine;

namespace Assets.Scripts.Arrows
{
	/// <summary>
	/// Arrow property that gives life to the player who shot it when it hits another player.
	/// </summary>
	public class LifestealArrow : ArrowProperty
	{

		public override void Effect(PlayerID hitPlayer)
		{
			// If a player was hit
			if (hitPlayer != 0)
			{
				Player.Controller sourceController = Data.GameManager.instance.GetPlayer(fromPlayer);
				float damage = GetComponent<ArrowController>().GetDamage();
				sourceController.LifeComponent.ModifyHealth(damage);
			}
		}
	}
}

