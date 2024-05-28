using TMPro;
using UnityEngine;

public class AppleScript1 : MonoBehaviour
{
    public int appleNumber; // Store the random number for this apple
    private GameManager1 gameManager1; // Reference to the GameManager
    public TextMeshPro num1; // Reference to the TextMeshPro component

    void Start()
    {
        gameManager1 = GameManager1.Instance;
        if (gameManager1.numberList.Count > 0)
        {
            int index = Random.Range(0, gameManager1.numberList.Count); // Pick a random index from the list
            appleNumber = gameManager1.numberList[index]; // Get the number from the list
            gameManager1.numberList.RemoveAt(index); // Remove the number from the list to avoid duplicates
            num1.text = appleNumber.ToString(); // Display the number on the apple
        }
        else
        {
            Debug.LogWarning("No numbers left in the list to assign to the apple.");
        }
    }

    private void OnMouseDown()
    {
        gameManager1.SelectApple(this); // Notify GameManager when apple is selected
    }
}

