using HarmonyLib;
using RimWorld.Planet;
using UnityEngine;

namespace CustomPlayerIcon;

[HarmonyPatch(typeof(WorldObject), nameof(WorldObject.ExpandingIconColor), MethodType.Getter)]
public static class WorldObject_ExpandingIconColor
{
    public static bool Prefix(WorldObject __instance, ref Color __result)
    {
        if (CustomPlayerIconComponent.Instance == null || __instance is not Settlement { Faction.IsPlayer: true } ||
            !CustomPlayerIconComponent.Instance.chosenColor.HasValue)
        {
            return true;
        }

        __result = CustomPlayerIconComponent.Instance.chosenColor.Value;
        return false;
    }
}