using System;
using UnityEngine;

public class ExpierienceManager : MonoBehaviour
{
    [SerializeField] LevelSettings levelSettings;

    private float expierience = 0;
    private Player player;
    private int lvlNr = 0;
    private Level CurrentLvl { get => levelSettings.Lvls[lvlNr]; }


    private void Start()
    {
        player = GameManager.instance.Player;
    }

    public void AddExpierience(float expierience)
    {
        this.expierience += expierience;

        if (IsPlayerReachedNewLvl())
            IncreaseLvl();
    }

    bool IsPlayerReachedNewLvl()
    {
        return expierience >= CurrentLvl.RequiredExpierience;
    }

    void IncreaseLvl()
    {
        lvlNr++;
        ShootingAbility shooting = player.GetComponent<ShootingAbility>();
        shooting?.Set(CurrentLvl.Weapon);
    }
}

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Level/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    public Level[] Lvls { get => lvls; }
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