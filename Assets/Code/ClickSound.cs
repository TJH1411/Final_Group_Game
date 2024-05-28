using UnityEngine;

public class ClickSounds : MonoBehaviour
{
    public AudioSource clickSound; // Reference to the AudioSource component

    void Start()
    {
        // Ensure there's an AudioSource attached to this GameObject
        if (clickSound == null)
        {
            clickSound = GetComponent<AudioSource>();
        }
    }

    public void PlayClickSound()
    {
        // Play the click sound only when this method is called
        clickSound.Play();
    }
}
