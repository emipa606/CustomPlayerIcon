using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace CustomPlayerIcon;

[HarmonyPatch(typeof(Faction), nameof(Faction.Color), MethodType.Getter)]
public static class Faction_Color
{
    public static bool Prefix(Faction __instance, ref Color __result)
    {
        if (CustomPlayerIconComponent.Instance == null || !__instance.IsPlayer ||
            !CustomPlayerIconComponent.Instance.chosenColor.HasValue)
        {
            return true;
        }

        __result = CustomPlayerIconComponent.Instance.chosenColor.Value;
        return false;
    }
}