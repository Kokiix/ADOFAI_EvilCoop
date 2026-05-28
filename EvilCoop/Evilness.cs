
using HarmonyLib;

[HarmonyPatch(typeof(scrPlayer), "Die")]
static class KillAllOnDeath
{
    static void Postfix()
    {
        ECPlugin.Instance.Config.Reload(); // Could maybe use a FileWatcher to save some expense
        if (!ECPlugin.evilEnabled.Value) return;

        foreach (var player in scrPlayerManager.instance.allPlayers)
        {
            if (player.alive)
            {
                player.Die(overload: false, multipress: false, failMessage: "Another player has died :(", hitbox: false);
            }
        }
    }
}