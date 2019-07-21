public interface IMovemenet
{
    void Move();
}

public interface IInput
{
    InputHandler Input { get; set; }
}

public interface ITwoAxisInput
{
    TwoAxisInput Input { get; set; }
}