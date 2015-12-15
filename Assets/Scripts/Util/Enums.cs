namespace Assets.Scripts.Util
{
    /*
     * Holds all of the enums used in the game
     */
    public static class Enums
    {
        public enum Arrows { Normal, Fireball, Ice, Thunder, Acid, Ricochet, Ghost, Gravity, NumTypes};
        public enum Tokens { Fireball, Ice, Thunder, Acid, Ricochet, Ghost, Gravity, Health};
        public enum RepetitionTimerSettings { Limited, Unlimited};
        public enum Frequency { None, Sparce, Infrequent, Average, Frequent, Abundant, NumTypes};
    }
}