
using HarmonyLib;

[HarmonyPatch(typeof(scrPlayer), "Die")]
static class KillAllOnDeath
{
    static void Postfix()
    {
        foreach (var player in scrPlayerManager.instance.allPlayers)
        {
            if (player.alive)
            {
                player.Die(overload: false, multipress: false, failMessage: "Another player has died :(", hitbox: false);
            }
        }
    }
}