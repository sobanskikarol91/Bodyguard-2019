using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMove", menuName = "Moving/PlayerSimple")]
public class PlayerMove : MoveType
{
    [SerializeField] AudioClip footStep;
    [SerializeField] float footStepVolume = 0.5f;

    private PlayerInput input;
    private AudioSource audioSource;

    public override Vector2 Direction => input.Moving.Direction;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        audioSource = AudioSourceFactory.GetAudioSource(transform, footStep, footStepVolume);
    }

    public override void Execute()
    {
        transform.position += (Vector3)(ability.Speed * Direction * Time.deltaTime);

        if (!audioSource.isPlaying && Direction.magnitude != 0)
            audioSource.Play();
        else if (audioSource.isPlaying && Direction.magnitude == 0)
            audioSource.Stop();
    }
}