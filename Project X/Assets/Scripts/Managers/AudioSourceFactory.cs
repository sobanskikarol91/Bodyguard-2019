using UnityEngine;

public static class AudioSourceFactory
{
    public static AudioSource GetAudioSource(Transform transform, AudioClip clip, float volume = 1f)
    {
        AudioSource audioSource = new GameObject("Audio: " + clip.name).AddComponent<AudioSource>();
        audioSource.transform.position = transform.position;
        audioSource.volume = volume;
        audioSource.clip = clip;
        return audioSource;
    }

    public static void ModifyAndPlay(AudioSource audioSource)
    {
        float orginalPitch = audioSource.pitch;
        float orginalVolume = audioSource.volume;

        audioSource.pitch = Random.Range(0.92f, 1.07f);
        audioSource.volume = Random.Range(0.95f, 1.05f);
        audioSource.Play();
    }

    public static void PlayClipAtPoint(AudioClip shotSnd, Transform transform)
    {
        AudioSource audioSource = GetAudioSource(transform, shotSnd);
        ModifyAndPlay(audioSource);
    }
}