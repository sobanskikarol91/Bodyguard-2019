public abstract class Character : InteractiveObject
{
    public StatusManager Status { get; protected set; } = new StatusManager();
}