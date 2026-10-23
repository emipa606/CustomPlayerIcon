using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace CustomPlayerIcon;

public class Dialog_ChoosePlayerIcon : Window
{
    private static string newIconPath;

    private static Color newColor;

    private static readonly Vector2 butSize = new(150f, 38f);

    private static bool firstTime = true;

    private Vector2 scrollPos;

    private float viewHeight;

    public Dialog_ChoosePlayerIcon()
    {
        absorbInputAroundWindow = true;
        if (!firstTime)
        {
            return;
        }

        newColor = Core.Colors[0];
        newIconPath = Core.AllIconPaths.First();
        firstTime = false;
    }

    public override Vector2 InitialSize => new(740f, 700f);

    public override void OnAcceptKeyPressed()
    {
        tryAccept();
        Event.current.Use();
    }

    public override void DoWindowContents(Rect inRect)
    {
        var rect2 = inRect;
        rect2.height -= CloseButSize.y;
        Text.Font = GameFont.Medium;
        Text.Font = GameFont.Small;
        var y = rect2.y;
        var mainRect = rect2;
        mainRect.yMax -= 4f;
        Widgets.Label(mainRect.x, ref y, mainRect.width, "Icon".Translate());
        mainRect.yMin = y;
        DoColorSelector(mainRect, ref y);
        mainRect.yMin = y;
        doIconSelector(mainRect);
        if (Widgets.ButtonText(new Rect(0f, inRect.height - butSize.y, butSize.x, butSize.y), "Back".Translate()))
        {
            Close();
        }

        if (Widgets.ButtonText(new Rect(inRect.width - butSize.x, inRect.height - butSize.y, butSize.x, butSize.y),
                "DoneButton".Translate()))
        {
            tryAccept();
        }
    }

    private void doIconSelector(Rect mainRect)
    {
        var num = 50;
        var viewRect = new Rect(0f, 0f, mainRect.width - 16f, viewHeight);
        Widgets.BeginScrollView(mainRect, ref scrollPos, viewRect);
        IEnumerable<string> allDefs = Core.AllIconPaths;
        var num2 = Mathf.FloorToInt(viewRect.width / (num + 5));
        var num3 = allDefs.Count();
        var num4 = 0;
        foreach (var item in allDefs)
        {
            var num5 = num4 / num2;
            var num6 = num4 % num2;
            var num7 = num4 >= num3 - (num3 % num2) ? num3 % num2 : num2;
            var num8 = (viewRect.width - (num7 * num) - ((num7 - 1) * 5)) / 2f;
            var rect = new Rect(num8 + (num6 * num) + (num6 * 5), (num5 * num) + (num5 * 5), num, num);
            Widgets.DrawLightHighlight(rect);
            Widgets.DrawHighlightIfMouseover(rect);
            if (item == newIconPath)
            {
                Widgets.DrawBox(rect);
            }

            GUI.color = newColor;
            GUI.DrawTexture(new Rect(rect.x + 5f, rect.y + 5f, 40f, 40f), ContentFinder<Texture2D>.Get(item));
            GUI.color = Color.white;
            if (Widgets.ButtonInvisible(rect))
            {
                newIconPath = item;
                SoundDefOf.Tick_High.PlayOneShotOnCamera();
            }

            viewHeight = Mathf.Max(viewHeight, rect.yMax);
            num4++;
        }

        GUI.color = Color.white;
        Widgets.EndScrollView();
    }

    private static void DoColorSelector(Rect mainRect, ref float curY)
    {
        const int num = 26;
        const float num2 = 98f;
        var num3 = Mathf.FloorToInt((mainRect.width - num2) / (num + 2));
        var num4 = Mathf.CeilToInt(Core.Colors.Count / (float)num3);
        GUI.BeginGroup(mainRect);
        GUI.color = newColor;
        GUI.DrawTexture(new Rect(5f, 5f, 88f, 88f), ContentFinder<Texture2D>.Get(newIconPath));
        GUI.color = Color.white;
        curY += num2;
        var num5 = 0;
        foreach (var item in Core.Colors)
        {
            var num6 = num5 / num3;
            var num7 = num5 % num3;
            var num8 = (num2 - (num * num4) - 2f) / 2f;
            var rect = new Rect(num2 + (num7 * num) + (num7 * 2), num8 + (num6 * num) + (num6 * 2), num, num);
            Widgets.DrawLightHighlight(rect);
            Widgets.DrawHighlightIfMouseover(rect);
            if (newColor == item)
            {
                Widgets.DrawBox(rect);
            }

            Widgets.DrawBoxSolid(new Rect(rect.x + 2f, rect.y + 2f, 22f, 22f), item);
            if (Widgets.ButtonInvisible(rect))
            {
                newColor = item;
                SoundDefOf.Tick_High.PlayOneShotOnCamera();
            }

            curY = Mathf.Max(curY, mainRect.yMin + rect.yMax);
            num5++;
        }

        GUI.EndGroup();
        curY += 4f;
    }

    private void tryAccept()
    {
        CustomPlayerIconComponent.Instance.chosenColor = newColor;
        CustomPlayerIconComponent.Instance.chosenTexPath = newIconPath;
        CustomPlayerIconComponent.Instance.ApplyIcon();
        Close();
    }
}