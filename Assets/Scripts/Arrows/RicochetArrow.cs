using TeamUtility.IO;

namespace Assets.Scripts.Arrows
{
    public class RicochetArrow : ArrowProperty
    {
        /// <summary>
        /// Number of bounce an arrow can bounce before stopping
        /// </summary>
        public static int bounces = 4;

        public override void Effect(PlayerID hitPlayer) { }
    } 
}
