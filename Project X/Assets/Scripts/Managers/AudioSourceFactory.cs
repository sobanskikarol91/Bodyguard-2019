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
}