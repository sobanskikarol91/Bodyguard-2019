using System;

public interface IInput
{
    InputHandler Input { get; set; }
}

public interface ITwoAxisInput
{
    TwoAxisInput Input { get; set; }
}

public interface IScore
{
   void UpdatedScore(float score);
}

public interface IRestart
{
    void Restart();
}

public interface IDependsOnLvl
{
    void OnGainNextLvl(int lvl);
}

public interface IDeath
{
    event Action Death;
}

public interface IAttack
{
    void Attack();
}