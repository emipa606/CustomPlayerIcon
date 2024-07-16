using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace CustomPlayerIcon;

[StaticConstructorOnStartup]
public static class Core
{
    public static readonly List<Color> colors =
    [
        new ColorInt(245, 245, 245).ToColor,
        new ColorInt(192, 192, 192).ToColor,
        new ColorInt(128, 128, 128).ToColor,
        new ColorInt(255, 115, 115).ToColor,
        new ColorInt(191, 86, 86).ToColor,
        new ColorInt(148, 67, 67).ToColor,
        new ColorInt(255, 199, 115).ToColor,
        new ColorInt(191, 149, 86).ToColor,
        new ColorInt(148, 115, 67).ToColor,
        new ColorInt(227, 255, 115).ToColor,
        new ColorInt(170, 191, 86).ToColor,
        new ColorInt(132, 148, 67).ToColor,
        new ColorInt(143, 255, 115).ToColor,
        new ColorInt(107, 191, 86).ToColor,
        new ColorInt(83, 148, 67).ToColor,
        new ColorInt(115, 255, 171).ToColor,
        new ColorInt(86, 191, 128).ToColor,
        new ColorInt(67, 148, 99).ToColor,
        new ColorInt(115, 255, 255).ToColor,
        new ColorInt(86, 191, 191).ToColor,
        new ColorInt(67, 148, 148).ToColor,
        new ColorInt(115, 171, 255).ToColor,
        new ColorInt(86, 128, 191).ToColor,
        new ColorInt(67, 99, 148).ToColor,
        new ColorInt(143, 115, 255).ToColor,
        new ColorInt(107, 86, 191).ToColor,
        new ColorInt(83, 67, 148).ToColor,
        new ColorInt(227, 115, 255).ToColor,
        new ColorInt(170, 86, 191).ToColor,
        new ColorInt(132, 67, 148).ToColor,
        new ColorInt(255, 115, 199).ToColor,
        new ColorInt(191, 86, 149).ToColor,
        new ColorInt(148, 67, 115).ToColor,
        new Color(0.1f, 0.1f, 0.1f),
        new Color(0.2f, 0.2f, 0.2f),
        new Color(0.31f, 0.28f, 0.26f),
        new Color(0.25f, 0.2f, 0.15f),
        new Color(0.3f, 0.2f, 0.1f),
        new ColorInt(90, 58, 32).ToColor,
        new ColorInt(132, 83, 47).ToColor,
        new ColorInt(193, 146, 85).ToColor,
        new ColorInt(237, 202, 156).ToColor
    ];

    public static readonly HashSet<string> allIconPaths = [];

    static Core()
    {
        colors.SortByColor(x => x);
        foreach (var t in ContentFinder<Texture2D>.GetAllInFolder("UI/Ideoligions"))
        {
            var path = $"UI/Ideoligions/{t.name}";
            if (ContentFinder<Texture2D>.Get(path, false) != null)
            {
                allIconPaths.Add(path);
            }
        }

        foreach (var def in DefDatabase<IdeoIconDef>.AllDefs)
        {
            allIconPaths.Add(def.iconPath);
        }

        foreach (var t in ContentFinder<Texture2D>.GetAllInFolder("CustomPlayerIcons"))
        {
            var path = $"CustomPlayerIcons/{t.name}";
            if (ContentFinder<Texture2D>.Get(path, false) != null)
            {
                allIconPaths.Add(path);
            }
        }

        new Harmony("CustomPlayerIcon.Mod").PatchAll();
    }
}