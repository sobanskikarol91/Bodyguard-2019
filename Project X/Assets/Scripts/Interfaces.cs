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
   void UpdateScore(float score);
}

public interface IRestart
{
    void Restart();
}