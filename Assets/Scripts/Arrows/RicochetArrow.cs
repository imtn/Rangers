using TeamUtility.IO;

namespace Assets.Scripts.Arrows
{
    public class RicochetArrow : ArrowProperty
    {
        public override void Effect(PlayerID hitPlayer)
        {
            if (colInfo.IsTrigger) return;
        }
    } 
}
