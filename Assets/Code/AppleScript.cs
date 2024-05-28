using TMPro;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public int appleNumber; // Store the random number for this apple
    private GameManager gameManager; // Reference to the GameManager
    public TextMeshPro num; // Reference to the TextMeshPro component

    void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager.numberList.Count > 0)
        {
            int index = Random.Range(0, gameManager.numberList.Count); // Pick a random index from the list
            appleNumber = gameManager.numberList[index]; // Get the number from the list
            gameManager.numberList.RemoveAt(index); // Remove the number from the list to avoid duplicates
            num.text = appleNumber.ToString(); // Display the number on the apple
        }
        else
        {
            Debug.LogWarning("No numbers left in the list to assign to the apple.");
        }
    }

    private void OnMouseDown()
    {
        gameManager.SelectApple(this); // Notify GameManager when apple is selected
    }
}

