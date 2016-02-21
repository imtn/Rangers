using UnityEngine;
using Assets.Scripts.Util;
using Assets.Scripts.Data;
using Assets.Scripts.Player;

namespace Assets.Scripts.Arrows
{
	/// <summary>
	/// Arrow property that spreads all enabled arrow properties to any players the
	/// arrow hits.
	/// </summary>
	public class VirusArrow : ArrowProperty
	{
		public override void Effect(PlayerID hitPlayer)
		{
			// If a player was hit
			if (hitPlayer != 0)
			{
				Archery hitArchery = GameManager.instance.GetPlayer(hitPlayer).ArcheryComponent;
				int spreadTypes = GameManager.instance.GetPlayer(fromPlayer).ArcheryComponent.ArrowTypes;

				// For each (non-normal) type of arrow, add that type to the hit player if the virus carries that type
				for(int i = 1; i < (int) Enums.Arrows.NumTypes; i++)
				{
					if(Bitwise.IsBitOn(spreadTypes, i))
					{
						hitArchery.AddArrowType((Enums.Arrows) i);
					}
				}
			}
		}
	}
}