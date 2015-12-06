namespace Assets.Scripts.Util
{
    /*
     * Handles any bitwise type operations for treating ints as registers
     */
    public static class Bitwise
    {
        // Checks to see if a certain bit is on
        public static bool IsBitOn(int reg, int bitPlace)
        {
            return (((1 << bitPlace) & reg) > 0);
        }
        // Turns a specific bit on
        public static int SetBit(int reg, int bitPlace)
        {
            return (reg |= (1 << bitPlace));
        }
        // Turns a specific bit off
        public static int ClearBit(int reg, int bitPlace)
        {
            reg &= ~(1 << bitPlace);
            return reg;
        }
    }
}