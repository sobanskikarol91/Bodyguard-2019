using UnityEngine;

public abstract class Status : CollisionEffect
{
    [SerializeField] protected float time;
    public abstract string Name { get; }
    protected InteractiveObject interactibleObject;


    public override void OnCollision(Collision2D collision, Transform transform)
    {
        interactibleObject = collision.gameObject.GetComponent<InteractiveObject>();

        if (interactibleObject && AreRequirementToAddStatusMet())
            AddStatus();
    }

    private void AddStatus()
    {
        Coroutine corutine = CreateStatus();
        interactibleObject.Status.TryToAddStatus(Name, corutine);
    }

    public abstract Coroutine CreateStatus();
    protected abstract bool AreRequirementToAddStatusMet();
}
