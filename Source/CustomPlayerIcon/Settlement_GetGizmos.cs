using System.Collections.Generic;
using HarmonyLib;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace CustomPlayerIcon;

[HarmonyPatch(typeof(Settlement), nameof(Settlement.GetGizmos))]
public static class Settlement_GetGizmos
{
    public static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> __result, Settlement __instance)
    {
        foreach (var gizmo in __result)
        {
            yield return gizmo;
        }

        if (__instance.Faction is { IsPlayer: true })
        {
            yield return new Command_Action
            {
                defaultLabel = "ChangePlayerIcon".Translate(),
                defaultDesc = "ChangePlayerIconDesc".Translate(),
                icon = ContentFinder<Texture2D>.Get("UI/ChangePlayerIcon"),
                action = delegate { Find.WindowStack.Add(new Dialog_ChoosePlayerIcon()); }
            };
        }
    }
}