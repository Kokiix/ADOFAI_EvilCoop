using BepInEx;
using BepInEx.Configuration;
using EvilCoop;
using HarmonyLib;
using UnityEngine;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class ECPlugin : BaseUnityPlugin
{
    Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);
    internal static ECPlugin Instance;

    internal static ConfigEntry<bool> evilEnabled;

    void Awake()
    {
        _harmony.PatchAll();
        Instance = this;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        evilEnabled = Config.Bind("General", "Enable Evil Mode", true, "Evil mode");
    }

    void OnDestroy()
    {
        _harmony.UnpatchSelf();
    }
}