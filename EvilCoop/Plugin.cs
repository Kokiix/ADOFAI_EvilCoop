using BepInEx;
using EvilCoop;
using HarmonyLib;
using UnityEngine;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class ECPlugin : BaseUnityPlugin
{
    Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);
    internal static ECPlugin Instance;

    void Awake()
    {
        _harmony.PatchAll();
        Instance = this;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;
    }

    void OnDestroy()
    {
        _harmony.UnpatchSelf();
    }
}