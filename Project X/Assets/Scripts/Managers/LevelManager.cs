using System;
using UnityEngine;

public class LevelManager : MonoBehaviour, IScore, IRestart
{
    [SerializeField] LvlSettings settings;

    private int lvlNr = 0;
    private float expierience = 0;
    private IDependsOnLvl[] lvlDependencies;

    private void Awake()
    {
        lvlDependencies = GetComponents<IDependsOnLvl>();
    }

    bool IsPlayerReachedNewLvl()
    {
        Func<float> NextLvlExpierience = () => settings.Lvls[lvlNr + 1];
        return expierience >= NextLvlExpierience();
    }

    void IncreaseLvl()
    {
        lvlNr++;
        Array.ForEach(lvlDependencies, l => l.OnGainNextLvl(lvlNr));
    }

    bool IsLastLvl()
    {
        return lvlNr == settings.MaxLvl - 1;
    }

    public void UpdatedScore(float score)
    {
        expierience = score;

        if (IsLastLvl())
            return;
        else if (IsPlayerReachedNewLvl())
            IncreaseLvl();
    }

    public void Restart()
    {
        expierience = lvlNr = 0;
    }
}