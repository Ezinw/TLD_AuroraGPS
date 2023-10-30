using Il2Cpp;
using HarmonyLib;

namespace AuroraGPS
{
    [HarmonyPatch(typeof(Panel_Map), "Update")]
    internal class AuroraGPS
    {
        private static bool _hasEnabledGPS;

        static void Postfix()
        {
            bool isAuroraActive = GameManager.GetAuroraManager().AuroraIsActive();

            if (isAuroraActive && !_hasEnabledGPS)
            {
                ConsoleManager.CONSOLE_map_enablegps();
                _hasEnabledGPS = true;
            }
            else if (!isAuroraActive && _hasEnabledGPS)
            {
                ConsoleManager.CONSOLE_map_enablegps();
                _hasEnabledGPS = false;
            }

        }

    }

}