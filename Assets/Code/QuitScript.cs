using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // Log message for debugging
        Application.Quit(); // Quit the application
    }
}
