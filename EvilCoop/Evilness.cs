
using HarmonyLib;

[HarmonyPatch(typeof(scrPlayer), "Die")]
static class KillAllOnDeath
{
    static void Postfix()
    {
        var evil = ECPlugin.Instance.Config.Bind("General", "Enable Evil Mode", true, "Evil mode").Value;
        if (!evil) return;

        foreach (var player in scrPlayerManager.instance.allPlayers)
        {
            if (player.alive)
            {
                player.Die(overload: false, multipress: false, failMessage: "Another player has died :(", hitbox: false);
            }
        }
    }
}