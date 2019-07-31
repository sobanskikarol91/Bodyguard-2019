using System;
using UnityEngine;

public class ExpierienceManager : MonoBehaviour
{
    [SerializeField] LevelSettings settings;

    private float expierience = 0;
    private Player player;
    private int lvlNr = 0;
    private Level CurrentLvl { get => settings.Lvls[lvlNr]; }
    private Level NextLvl { get => settings.Lvls[lvlNr + 1]; }


    private void Start()
    {
        player = GameManager.instance.Player;
    }

    public void AddExpierience(float expierience)
    {
        Debug.Log(this.expierience + " " + expierience);
        this.expierience += expierience;

        if (IsLastLvl())
            return;
        else if (IsPlayerReachedNewLvl())
            IncreaseLvl();
    }

    bool IsPlayerReachedNewLvl()
    {
        return expierience >= NextLvl.RequiredExpierience;
    }

    void IncreaseLvl()
    {
        lvlNr++;
        ShootingAbility shooting = player.GetComponent<ShootingAbility>();
        shooting?.Set(CurrentLvl.Weapon);
    }

    bool IsLastLvl()
    {
        return lvlNr == settings.MaxLvl - 1;
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