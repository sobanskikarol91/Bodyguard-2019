using System;
using UnityEngine;

public class ExpierienceManager : MonoBehaviour, IScore, IRestart
{
    [SerializeField] LevelSettings settings;

    private float expierience = 0;
    private ShootingAbility playerShootingAbility;
    private int lvlNr = 0;
    private Level CurrentLvl { get => settings.Lvls[lvlNr]; }
    private Level NextLvl { get => settings.Lvls[lvlNr + 1]; }


    private void Start()
    {
        playerShootingAbility = GameManager.instance.Player.GetComponent<ShootingAbility>();
    }

    bool IsPlayerReachedNewLvl()
    {
        return expierience >= NextLvl.RequiredExpierience;
    }

    void IncreaseLvl()
    {
        lvlNr++;
        playerShootingAbility?.Set(CurrentLvl.Weapon);
    }

    bool IsLastLvl()
    {
        return lvlNr == settings.MaxLvl - 1;
    }

    public void UpdateScore(float score)
    {
        expierience = score;

        if (IsLastLvl())
            return;
        else if (IsPlayerReachedNewLvl())
            IncreaseLvl();
    }

    public void Restart()
    {
        expierience =  lvlNr = 0;
        playerShootingAbility?.Set(CurrentLvl.Weapon);
    }
}

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Level/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    public Level[] Lvls { get => lvls; }
    public int MaxLvl { get => lvls.Length; }
    [SerializeField] Level[] lvls;
}

[Serializable]
public class Level
{
    public Weapon Weapon { get => weapon; }
    public float RequiredExpierience { get => requiredExpierience; }

    [SerializeField] Weapon weapon;
    [SerializeField] float requiredExpierience;
}