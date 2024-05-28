using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundEffectSource;

    // Play music
    public void PlayMusic()
    {
        musicSource.Play();
    }

    // Play sound effect
    public void PlaySoundEffect()
    {
        soundEffectSource.Play();
    }
}
