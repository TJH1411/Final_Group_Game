using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public AudioSource clickSound;

    void Start()
    {
        // Ensure there's an AudioSource attached to this GameObject
        if (clickSound == null)
        {
            clickSound = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check for mouse clicks
        if (Input.GetMouseButtonDown(0)) // Change to 1 for right click, 2 for middle click
        {
            Debug.Log("Mouse button clicked."); // Debug log for troubleshooting

            // Cast a ray from the mouse position to detect if it hits this GameObject
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // If the ray hits this GameObject, play the click sound
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Object clicked."); // Debug log for troubleshooting
                PlayClickSound();
            }
        }
    }

    void PlayClickSound()
    {
        Debug.Log("Playing click sound."); // Debug log for troubleshooting
        // Play the click sound
        clickSound.Play();
    }
}
