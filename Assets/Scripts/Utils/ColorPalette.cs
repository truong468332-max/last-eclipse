using UnityEngine;

namespace LastEclipse.Utils
{
    /// <summary>
    /// Last Eclipse color palette
    /// Dark, gritty, post-apocalyptic aesthetic
    /// </summary>
    public static class ColorPalette
    {
        // Main colors
        public static Color AshGray = new Color(0.16f, 0.16f, 0.16f);        // #2A2A2A
        public static Color BloodRed = new Color(0.8f, 0f, 0f);              // #CC0000
        public static Color RadioactiveGreen = new Color(0f, 1f, 0f);        // #00FF00
        public static Color DeepPurple = new Color(0.29f, 0f, 0.5f);         // #4A0080
        public static Color PureBlack = Color.black;                         // #000000
        public static Color PureWhite = Color.white;                         // #FFFFFF

        // Secondary colors
        public static Color MutationBioGreen = new Color(0f, 0.8f, 0f);      // Mutated life
        public static Color RadiationYellow = new Color(1f, 1f, 0f);         // Radiation
        public static Color CharcoalGray = new Color(0.2f, 0.2f, 0.2f);      // Shadows
        public static Color DeathOrange = new Color(1f, 0.5f, 0f);           // Fire/Death
    }
}
