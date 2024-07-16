using RimWorld;
using UnityEngine;
using Verse;

namespace CustomPlayerIcon;

public class CustomPlayerIconComponent : GameComponent
{
    public static CustomPlayerIconComponent Instance;
    public Color? chosenColor;
    public string chosenTexPath;

    public CustomPlayerIconComponent(Game game)
    {
    }

    public override void StartedNewGame()
    {
        Instance = this;
        base.StartedNewGame();
    }

    public override void LoadedGame()
    {
        Instance = this;
        base.LoadedGame();
    }

    public override void FinalizeInit()
    {
        Instance = this;
        base.FinalizeInit();
        ApplyIcon();
    }

    public void ApplyIcon()
    {
        LongEventHandler.ExecuteWhenFinished(delegate
        {
            if (!chosenTexPath.NullOrEmpty())
            {
                Faction.OfPlayer.def.factionIcon = ContentFinder<Texture2D>.Get(chosenTexPath);
            }
        });
    }

    public override void ExposeData()
    {
        Instance = this;
        base.ExposeData();
        Scribe_Values.Look(ref chosenColor, "chosenColor");
        Scribe_Values.Look(ref chosenTexPath, "chosenTexPath");
    }
}